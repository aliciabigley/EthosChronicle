using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using NReco.VideoConverter;
using System.Drawing;
using EthosChronicle.Models;

namespace EthosChronicle.Controllers
{
    public class VideoGalleryController : Controller
    {
        public ActionResult Gallery()
        {
            List<VideoGallery> userImage = new List<VideoGallery>();
            userImage.Clear();
            List<VideoGallery> all = new List<VideoGallery>();
            //UploadImagesEntities dc = new UploadImagesEntities();
            using (UploadVideosEntities dc = new UploadVideosEntities())
            {

                if (dc.VideoGalleries != null)
                {
                    var userId = User.Identity.GetUserId();
                    foreach (var image in dc.VideoGalleries)
                    {
                        if (image.Id == userId && image.Id != null)
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
        public ActionResult Upload(VideoGallery IG)
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
            IG.VideoSize = IG.File.ContentLength;

            byte[] data = new byte[IG.File.ContentLength];
            IG.File.InputStream.Read(data, 0, IG.File.ContentLength);
            IG.VideoData = data;
            using (UploadVideosEntities dc = new UploadVideosEntities())
            {
                IG.Id = User.Identity.GetUserId(); //This assigns the userid as the Ig.Id
                dc.VideoGalleries.Add(IG);
                dc.SaveChanges();
            }

            return RedirectToAction("gallery");
        }
        public FileResult Download(int VideoId)
        {
            UploadVideosEntities dc = new UploadVideosEntities();
            var file = dc.VideoGalleries.Where(x => x.VideoId == VideoId).First();
            return new FileContentResult(file.VideoData, "image/ jpeg") { FileDownloadName = file.FileName };
        }

        public ActionResult GetThumbnail(int VideoId)
        {
            UploadVideosEntities dc = new UploadVideosEntities();

            using (dc = new UploadVideosEntities())
            {
                // fetch video from database
                VideoGallery ig = new VideoGallery();
                ig = dc.VideoGalleries.Where(m => m.VideoId == VideoId).FirstOrDefault();

                Image thumbnail = null;

                var ffMpeg = new FFMpegConverter();
                float? frameTime = 07;

                var path = Server.MapPath("~/Upload/TempUpload/" + ig.FileName);

                //thumnail path
                string imageFilePath = Server.MapPath("~/Upload/TempUpload/" + ig.FileName + ".jpg");

                // Get thumnail using NReco.VideoConverter
                ffMpeg.GetVideoThumbnail(path, imageFilePath, frameTime);

                //Open image and read it to thumnail
                using (FileStream imageStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
                {
                    thumbnail = Image.FromFile(imageFilePath);
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    // Save thumbnail image
                    thumbnail.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                    // Add it to Response
                    HttpContext.Response.ContentType = "image/bmp";
                    HttpContext.Response.BinaryWrite(ms.ToArray());
                    HttpContext.Response.End();
                }

            }
            return new EmptyResult();

        }
        //[HttpGet]
        //public EmptyResult VideoStream(int id = 0)
        //{
        //    ApplicationDbContext db = new ApplicationDbContext();
        //    UploadVideosEntities dc = new UploadVideosEntities();

        //    using (db = new ApplicationDbContext())
        //    {
        //        ImageGallery vm = new ImageGallery();
        //        vm = dc.VideoGalleries.Where(m => m.ImageId == id).FirstOrDefault();  //fetch video from database of particular id


        //        HttpContext.Response.AddHeader("Content-Disposition", "attachment; filename=" + vm.FileName);  //add header to httpcontext > response.
        //        HttpContext.Response.BinaryWrite(vm.ImageData);  //write bytes to httpcontext response

        //        return new EmptyResult(); ;
        //    }

        //}
        // GET: VideoGallery
        public ActionResult Index()
        {
            return View();
        }
    }
}