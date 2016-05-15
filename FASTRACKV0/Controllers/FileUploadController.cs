using FASTrack.ViewModel;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace FASTrack.Controllers
{
    public class FileUploadController : Controller
    {
        [HttpGet]
        public ActionResult Index(int id)//idmaster
        {
            var model = new UploadFile();
            model.Id = id;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(int id, UploadFile model)//idmaster
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            byte[] uploadFile = new byte[model.File.InputStream.Length];
            model.File.InputStream.Read(uploadFile, 0, uploadFile.Length);

            string fileFolder = Server.MapPath("~/Files");
            if (!Directory.Exists(fileFolder))
            {
                Directory.CreateDirectory(fileFolder);
            }
            string folderMaster = id.ToString().PadLeft(10, '0');
            string folder = Server.MapPath("~/Files/" + folderMaster);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string file = Path.Combine(folder, Guid.NewGuid().ToString() + "." + Path.GetExtension(model.File.FileName));
            System.IO.File.WriteAllBytes(file, uploadFile);

            return Content("File Uploaded.");
        }

        public ActionResult Download(int id)
        {
            FASTrack.ViewModel.UploadFile file = new UploadFile();
            file.Id = id;
            return View(file);
        }

        public FileContentResult FileDownload(int id)
        {
            string fileName = "";
            string folderMaster = id.ToString().PadLeft(10, '0');
            string folder = Server.MapPath("~/Files/" + folderMaster);
            string[] files = Directory.GetFiles(folder);
            byte[] fileBytes = null;
            foreach (string file in files)
            {
                fileBytes = System.IO.File.ReadAllBytes(file);
                fileName = Path.GetFileName(file);
            }
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

    }
}