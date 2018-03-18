using DistributedPartlyCloudDatabase.BLL.Interface.Services;
using DistributedPartlyCloudDatabase.Web.ViewModels;
using System;
using System.Web.Mvc;

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
        public ActionResult Login(LoginViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (System.Web.Security.Membership.ValidateUser(viewModel.Email, viewModel.Password))
                {
                    var user = _service.GetUserByEmail(viewModel.Email);

                    if (user.Banned)
                        return PartialView("BannedPartial");

                    FormsAuthentication.SetAuthCookie(viewModel.Email, viewModel.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid login or password!");
            }
            return View(viewModel);
        }
    }
}