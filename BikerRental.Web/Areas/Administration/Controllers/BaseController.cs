using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BikerRental.Web.Areas.Administration.Controllers
{
    public class BaseController : Controller
    {
        protected void DeleteFile(string fileName)
        {
            string path = Server.MapPath("~/Content/Images/Raw");
            string completePath = Path.Combine(path, fileName);
            System.IO.File.Delete(completePath);
        }

        protected string SaveFile(HttpPostedFileBase image, ModelStateDictionary ModelState)
        {
            if (image != null)
            {
                string path = Server.MapPath("~/Content/Images/Raw");


                if (image.ContentLength > 10240 && false)
                {
                    ModelState.AddModelError("photo", "The size of the file should not exceed 10 KB");
                    return null;
                }

                var supportedTypes = new[] { "jpg", "jpeg", "png" };

                var fileExt = System.IO.Path.GetExtension(image.FileName).Substring(1);

                if (!supportedTypes.Contains(fileExt))
                {
                    ModelState.AddModelError("Image", "Invalid type. Only the following types (jpg, jpeg, png) are supported.");
                    return null;
                }
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                image.SaveAs(Path.Combine(path, image.FileName));
                return image.FileName;
            }
            return null;
        }
	}
}