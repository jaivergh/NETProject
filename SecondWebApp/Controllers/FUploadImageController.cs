using SecondWebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecondWebApp.Controllers
{
    public class FUploadImageController : Controller
    {
        // GET: FUploadImage
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ImageUpload(ProductViewModel productViewModel)
        {

            MVCDataBaseEntities db = new MVCDataBaseEntities();
            HttpPostedFileWrapper file = productViewModel.ImageFile;
            byte[] imageByte = null;
            string fileName = "";
            int imageStoreId;
            if (file != null)
            {
                fileName = Path.GetFileName(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file.FileName);

                file.SaveAs(Server.MapPath("/UploadedImages/" + fileName));

                BinaryReader binaryReader = new BinaryReader(file.InputStream);
                imageByte = binaryReader.ReadBytes(file.ContentLength);


                //ImageStore imageStore = new ImageStore();

                //imageStore.ImageName = file.FileName;
                //imageStore.ImageByte = imageByte;
                //imageStore.ImagePath = "/UploadedImages/" + fileName;
                //imageStore.IsDeleted = false;

                //db.ImageStore.Add(imageStore);
                //db.SaveChanges();

                //imageStoreId = imageStore.ImageId;

            }

            return Json(fileName, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ImageUploadSQL(ProductViewModel productViewModel)
        {

            MVCDataBaseEntities db = new MVCDataBaseEntities();
            HttpPostedFileWrapper file = productViewModel.ImageFile;
            byte[] imageByte = null;
            string fileName = "";
            int imageStoreId = 0;
            if (file != null)
            {
                fileName = Path.GetFileName(file.FileName);

                BinaryReader binaryReader = new BinaryReader(file.InputStream);
                imageByte = binaryReader.ReadBytes(file.ContentLength);


                ImageStore imageStore = new ImageStore();

                imageStore.ImageName = file.FileName;
                imageStore.ImageByte = imageByte;
                imageStore.ImagePath = "/UploadedImages/" + fileName;
                imageStore.IsDeleted = false;

                db.ImageStore.Add(imageStore);
                db.SaveChanges();

                imageStoreId = imageStore.ImageId;

            }

            return Json(imageStoreId, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ImageRetrieve(int imageID)
        {
            MVCDataBaseEntities db = new MVCDataBaseEntities();

            ImageStore imageStore = db.ImageStore.SingleOrDefault(x => x.ImageId == imageID);

            return File(imageStore.ImageByte, "image/jpg");

        }
    }
}