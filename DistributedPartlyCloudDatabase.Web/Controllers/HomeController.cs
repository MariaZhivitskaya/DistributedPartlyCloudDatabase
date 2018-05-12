using DistributedPartlyCloudDatabase.BLL.Interface.Entities;
using DistributedPartlyCloudDatabase.BLL.Interface.Services;
using DistributedPartlyCloudDatabase.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DistributedPartlyCloudDatabase.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;

        public HomeController(IUserService uService)
        {
            userService = uService;
        }

        public ActionResult Index() => View();

        public ActionResult Home()
        {
            string nickname = Membership.GetUser().UserName;
            UserEntity userEntity = userService.GetUserByNickname(nickname);

            var model = new UserViewModel
            {
                Id = userEntity.Id,
                Email = userEntity.Email,
                Nickname = userEntity.Nickname,
                Surname = userEntity.Surname,
                Name = userEntity.Name,
                Birthdate = userEntity.Birthdate,
                RoleId = userEntity.RoleId,
            };

            return View(model);
        }
        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}