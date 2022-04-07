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
    
<<<<<<< HEAD
    private IHostingEnvironment Environment;
 
    public DownloadController(IHostingEnvironment _environment)
    {
        Environment = _environment;
    }

    public IActionResult Index()
    {
        //Fetch all files in the Folder (Directory).
        string[] filePaths = Directory.GetFiles(Path.Combine(this.Environment.WebRootPath, "Files/"));
 
        //Copy File names to Model collection.
        List<CSVModel> files = new List<CSVModel>();
        foreach (string filePath in filePaths)
        {
            files.Add(new CSVModel {

                 FileName = Path.GetFileName(filePath) 
                 
                 });
        }
 
        return View(files);
    }

        public FileStreamResult DownloadFile(string fileName)
    {
        //Determine the Content Type of the File.
        string contentType = "";
        fileName="File.csv";
        new FileExtensionContentTypeProvider().TryGetContentType(fileName, out contentType);
 
        //Build the File Path.
        string path = Path.Combine(this.Environment.WebRootPath, "Files/") + fileName;
 
        //Read the File data into FileStream.
        FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
 
        //Send the File to Download.
        return new FileStreamResult(fileStream, contentType);
    }



=======
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
            //Determine the Content Type of the File.
            string contentType = "";
            
            new FileExtensionContentTypeProvider().TryGetContentType(csv.FileName, out contentType);
    
            //Build the File Path.
            string path = Path.Combine(this.Environment.WebRootPath, "Files/") + csv.FileName;
    
            //Read the File data into FileStream.
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
    
            //Send the File to Download.
            return new FileStreamResult(fileStream, contentType);

            // 3- Delete the file
            // if(File.Exists(@"C:\test.txt"))
            // {
            //     File.Delete(@"C:\test.txt");
            // }
        }
>>>>>>> cff145e23abc0dc08d8e5d73b27e068b05406e06


    }
}
