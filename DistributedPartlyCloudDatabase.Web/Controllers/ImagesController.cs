using DistributedPartlyCloudDatabase.BLL.Interface.Services;
using DistributedPartlyCloudDatabase.Web.Infrastructure.Mappers;
using DistributedPartlyCloudDatabase.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DistributedPartlyCloudDatabase.Web.Controllers
{
    public class ImagesController : Controller
    {
        private readonly IUserService userService;
        private readonly IImageService imageService;

        public ImagesController(IUserService userService, IImageService imageService)
        {
            this.userService = userService;
            this.imageService = imageService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Images()
        {
            string nickname = Membership.GetUser().UserName;
           // var user = _userService.GetUserByEmail(email);

            var model = imageService.GetByUserNickname(nickname).Select(img => new ImageViewModel()
            {
                BinaryImage = img.BinaryImage,
                UserNickname = img.UserNickname
            });

            return View(model);
        }

        [HttpPost]
        public ActionResult UploadImages()
        {
            foreach (string file in Request.Files)
            {
                var upload = Request.Files[file];
                if (upload != null)
                {
                    byte[] fileData;
                    using (var binaryReader = new BinaryReader(upload.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(upload.ContentLength);
                    }

                    string hash = imageService.ComputeHashCode(fileData);

                    var nickname = Membership.GetUser().UserName;
                  //  var user = userService.GetUserByNickname(email);

                    var image = new ImageViewModel
                    {
                        BinaryImage = fileData,
                        UserNickname = nickname,
                        HashCode = hash
                    };

                    imageService.CreateImage(image.ToBllImage());

                 //   var model = image;
                    return PartialView("_Image", image);
                }
            }
            return PartialView("_Image", null);
        }


        public ActionResult RenderImage(byte[] srcImg)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream(srcImg);
            ms.Position = 0;
            return new FileStreamResult(ms, "image/jpeg");
        }
    }
}