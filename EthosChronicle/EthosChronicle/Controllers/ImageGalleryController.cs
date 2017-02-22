using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace EthosChronicle.Controllers
{
    public class ImageGalleryController : Controller
    {
        
        public  ActionResult Gallery()
        {
            List<ImageGallery> userImage = new List<ImageGallery>();
            userImage.Clear();
            List<ImageGallery> all = new List<ImageGallery>();
            //UploadImagesEntities dc = new UploadImagesEntities();
            using (UploadImagesEntities dc = new UploadImagesEntities())
            {
                
                if (dc.ImageGalleries != null)
                {
                    var userId = User.Identity.GetUserId();
                    foreach(var image in dc.ImageGalleries)
                    {
                        if(image.Id == userId && image.Id != null)
                        {
                            userImage.Add(image);
                        }
                    }
                   
                }
                //all = dc.ImageGalleries.ToList();
            }
            return View(userImage);
        }
        public ActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Upload(ImageGallery IG)
        {
            //try
            //{
            //    if (IG.File.ContentLength > (2 * 1024 * 1024))
            //    {
            //        ModelState.AddModelError("CustomError", "File size must be less than 2 MB");
            //        return View();
            //    }
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("Try uploading a smaller file");
            //    throw;
            //}
            //if (IG.File.ContentLength > (2 * 1024 * 1024))
            //{
            //    ModelState.AddModelError("CustomError", "File size must be less than 2 MB");
            //    return View();
            //}
            //if (!(IG.File.ContentType == "image/jpeg" || IG.File.ContentType == "image/gif" || IG.File.ContentType == "image/png" || IG.File.ContentType == "image/jpg" || IG.File.ContentType == "video/mp4"))
            //{
            //    ModelState.AddModelError("CustomError", "File type allowed : jpeg and gif");
            //    return View();
            //}

            IG.FileName = IG.File.FileName;
            IG.ImageSize = IG.File.ContentLength;

            byte[] data = new byte[IG.File.ContentLength];
            IG.File.InputStream.Read(data, 0, IG.File.ContentLength);
            IG.ImageData = data;
            using(UploadImagesEntities dc = new UploadImagesEntities())
            {
                IG.Id = User.Identity.GetUserId(); //This assigns the userid as the Ig.Id
                dc.ImageGalleries.Add(IG);
                dc.SaveChanges();
            }

            return RedirectToAction("gallery");
        }
        public FileResult Download(int ImageId)
        {
            UploadImagesEntities dc = new UploadImagesEntities();
            var file = dc.ImageGalleries.Where(x => x.ImageId == ImageId).First();
            return new FileContentResult(file.ImageData, "image/ jpeg") { FileDownloadName = file.FileName };
        }


    }
}