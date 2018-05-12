using DistributedPartlyCloudDatabase.BLL.Interface.Entities;
using DistributedPartlyCloudDatabase.BLL.Interface.Services;
using DistributedPartlyCloudDatabase.Web.Infrastructure;
using DistributedPartlyCloudDatabase.Web.Providers;
using DistributedPartlyCloudDatabase.Web.ViewModels;
using System;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace DistributedPartlyCloudDatabase.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUserService userService;

        public AccountController(IUserService service)
        {
            userService = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register() => View();

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            if (registerViewModel.Captcha != (string)Session[CaptchaImage.CaptchaValueKey])
            {
                ModelState.AddModelError("Captcha", "Incorrect input!");
                return View(registerViewModel);
            }

            var existingUser = userService.GetAllUserEntities().Any(user => user.Email.Contains(registerViewModel.Email));
            if (existingUser)
            {
                ModelState.AddModelError("", "Such email already registered!");
                return View(registerViewModel);
            }

            existingUser = userService.GetAllUserEntities().Any(user => user.Nickname.Contains(registerViewModel.Nickname));
            if (existingUser)
            {
                ModelState.AddModelError("", "Such nickname already registered!");
                return View(registerViewModel);
            }

            if (ModelState.IsValid)
            {
                var subStrings = registerViewModel.Birthdate.Split('/');
                var date = new DateTime(int.Parse(subStrings[2]), int.Parse(subStrings[1]), int.Parse(subStrings[0]));

                var membershipUser = 
                    ((CustomMembershipProvider)Membership.Provider).CreateUser
                    (registerViewModel.Email, registerViewModel.Password,  registerViewModel.Nickname, registerViewModel.Surname, registerViewModel.Name, date);

                if (membershipUser != null)
                {
                    FormsAuthentication.SetAuthCookie(registerViewModel.Nickname, false);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Sorry, an error occured while registration...");
            }

            return View(registerViewModel);
        }

        [AllowAnonymous]
        public ActionResult Captcha()
        {
            Session[CaptchaImage.CaptchaValueKey] =
                new Random(DateTime.Now.Millisecond).Next(1111, 9999).ToString(CultureInfo.InvariantCulture);
            var captchaImage = new CaptchaImage(Session[CaptchaImage.CaptchaValueKey].ToString(), 211, 50, "Helvetica");

            // Change the response headers to output a JPEG image.
            Response.Clear();
            Response.ContentType = "image/jpeg";

            // Write the image to the response stream in JPEG format.
            captchaImage.Image.Save(Response.OutputStream, ImageFormat.Jpeg);

            // Dispose of the CAPTCHA image object.
            captchaImage.Dispose();
            return null;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            Type type = HttpContext.User.GetType();
            Type identity = HttpContext.User.Identity.GetType();
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginViewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(loginViewModel.Email, loginViewModel.Password))
                {
                    UserEntity userEntity = userService.GetUserByEmail(loginViewModel.Email);

                    //if (user.Banned)
                    //    return PartialView("BannedPartial");
                    
                    //TODO: create separate method for getting nickname by email
                    var existingUser = userService.GetAllUserEntities().FirstOrDefault(user => user.Email.Contains(loginViewModel.Email));

                    FormsAuthentication.SetAuthCookie(existingUser.Nickname, loginViewModel.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid login or password!");
            }

            return View(loginViewModel);
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}