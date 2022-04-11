using System;
using accmapdecision.Models;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using System.Collections.Generic;
using System.Linq;

namespace accmapdecision.Controllers {

    public class DownloadController : Controller {

        private IHostingEnvironment Environment;

        public DownloadController(IHostingEnvironment _environment)
        {
            Environment = _environment;
        }

            [HttpPost]
            public FileStreamResult DownloadFile(UserResponseManager userResponseManagerModel)
        {
            // 1- Create CSV with the data
            CSVModel csv = new CSVModel();
            csv.WriteCSV(userResponseManagerModel.userResponse);

            // 2- Download the file
            string contentType = ""; //Determine the Content Type of the File.

            new FileExtensionContentTypeProvider().TryGetContentType(csv.FileName, out contentType);

            //Build the File Path.
            string path = Path.Combine(this.Environment.WebRootPath, "Files/") + csv.FileName;

            //Read the File data into FileStream.
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);

            // 3- Delete the local file
            if(System.IO.File.Exists(@path))
            {
                System.IO.File.Delete(@path);   
            }
            //Send the File to Download.
            return new FileStreamResult(fileStream, contentType);
        }


    }
}