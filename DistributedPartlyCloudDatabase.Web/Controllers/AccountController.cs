using DistributedPartlyCloudDatabase.BLL.Interface.Services;
using DistributedPartlyCloudDatabase.Web.Infrastructure;
using DistributedPartlyCloudDatabase.Web.Providers;
using DistributedPartlyCloudDatabase.Web.ViewModels;
using System;
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
                    FormsAuthentication.SetAuthCookie(registerViewModel.Email, false);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Sorry, an error occured while registration...");
            }

            return View(registerViewModel);
        }

        //[AllowAnonymous]
        //public ActionResult Login(string returnUrl)
        //{
        //    Type type = HttpContext.User.GetType();
        //    Type identity = HttpContext.User.Identity.GetType();
        //    ViewBag.ReturnUrl = returnUrl;

        //    return View();
        //}

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(LoginViewModel viewModel, string returnUrl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (System.Web.Security.Membership.ValidateUser(viewModel.Email, viewModel.Password))
        //        {
        //            var user = _service.GetUserByEmail(viewModel.Email);

        //            if (user.Banned)
        //                return PartialView("BannedPartial");

        //            FormsAuthentication.SetAuthCookie(viewModel.Email, viewModel.RememberMe);
        //            if (Url.IsLocalUrl(returnUrl))
        //            {
        //                return Redirect(returnUrl);
        //            }
        //            return RedirectToAction("Index", "Home");
        //        }
        //        ModelState.AddModelError("", "Invalid login or password!");
        //    }
        //    return View(viewModel);
        //}
    }
}