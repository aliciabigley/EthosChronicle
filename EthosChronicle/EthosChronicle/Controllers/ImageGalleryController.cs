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
            List<ImageGallery> all = new List<ImageGallery>();
            UploadImagesEntities dc = new UploadImagesEntities();

                using (dc)
            {
                if (dc.ImageGalleries != null)
                {
                    var id = User.Identity.GetUserId();
                    foreach(var image in dc.ImageGalleries)
                    {
                        if(image.Id == id && image.Id != null)
                        {
                            all = dc.ImageGalleries.ToList();
                        }
                    }
                }
                //all = dc.ImageGalleries.ToList();
            }
            return View(all);
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
            //if (!(IG.File.ContentType == "image/jpeg" || IG.File.ContentType == "image/gif"))
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

        //public ImageGallery Base64ToImage(string base64String)
        //{
        //    //// Convert Base64 String to byte[]
        //    byte[] imageBytes = Convert.FromBase64String(base64String);
        //    MemoryStream ms = new MemoryStream(imageBytes, 0,
        //      imageBytes.Length);

        //    // Convert byte[] to Image
        //    ms.Write(imageBytes, 0, imageBytes.Length);
        //    Image image = Image.FromStream(ms, true);
        //    return image;
        //}
        //public ActionResult Download(ImageGallery ig)
        //{
        //  //byte[] image = @Convert.FromBase64String(Encoding.ASCII.GetString(ig.ImageData));
        //  //  return RedirectToAction("gallery");
        //}
            //    int j = 0;
            //    int i = 0;
            //        while(j < i + 4 && j < ig.ImageData.Count())
            //            {


            //                  Convert.ToBase64StringImageData,0,Model[j].ImageData.Length)

            //            j++;
            //        }
            //        ////List<ImageGallery> all = new List<ImageGallery>();
            //        ////for(int i = 0; i< da)
            //        //byte[] contents = IG.ImageData;
            //        //string fileName = IG.FileName;
            //        //return File(contents, fileName);
            //        ////return new FileContentResult(contents,fileName);
            //    }

            // GET: ImageGallery
            //public ActionResult Index()
            //{
            //    return View();
            //}
        }
}