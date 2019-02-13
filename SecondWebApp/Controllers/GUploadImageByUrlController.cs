using SecondWebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SecondWebApp.Controllers
{
    public class GUploadImageByUrlController : Controller
    {
        // GET: GUploadImageByUrl
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult ImageUploadUrl(ProductViewModel productViewModel)
        {

            MVCDataBaseEntities db = new MVCDataBaseEntities();
            byte[] imageByte = null;
            int imageStoreId = 0;
            if (productViewModel != null)
            {
                if (productViewModel.ImageUrl != null)
                {
                    imageByte = DownloadImage(productViewModel.ImageUrl);


                    ImageStore imageStore = new ImageStore();

                    //imageStore.ImageName = file.FileName;
                    imageStore.ImageByte = imageByte;
                    imageStore.ImagePath = productViewModel.ImageUrl;
                    imageStore.IsDeleted = false;

                    db.ImageStore.Add(imageStore);
                    db.SaveChanges();

                    imageStoreId = imageStore.ImageId;
                }

            }

            return Json(imageStoreId, JsonRequestBehavior.AllowGet);
        }

        public byte[] DownloadImage(string url)
        {
            var webClient = new WebClient();
            byte[] imageBytes = webClient.DownloadData(url);
            return imageBytes;
        }

    }
}