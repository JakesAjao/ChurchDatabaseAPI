using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ChurchDatabaseAPI.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace ChurchDatabaseAPI.Controllers
{
    [Route("churchdatabaseapi/image")]
    [EnableCors("AllowAllHeaders")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ApplicationDatabaseContext _context;
        public ImageController(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        [HttpPost("uploadphoto")]
        public String UploadFile([FromForm]IFormFile file)
        {
            Image img = new Image();
            try
            {
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                ms.Close();
                ms.Dispose();

                Image imgdata = new Image();
                imgdata.ImageTitle = file.FileName;
                imgdata.ImageData = ms.ToArray();
                imgdata.Message = "Image Successfully uploaded.";
                imgdata.CreatedDate = DateTime.UtcNow;
                _context.Image.Add(imgdata);
                _context.SaveChanges();

                int id = imgdata.Id; // Yes it's here

                return Convert.ToString(id);
            }
            catch (Exception e)
            {
                img.Id = -1;
                img.Message = "Image Could Not Be uploaded. Error: " + e.ToString();
                return Convert.ToString(-1);
            }
        }
        [HttpPost("updatephoto")]
        public String UpdateFile([FromForm]IFormFile file, [FromForm]String imageId)
        {
            Image img = new Image();
            try
            {
                //string obj = string.Parse(imageId);
                var result = _context.Image.SingleOrDefault(b => b.Id == Convert.ToInt64(imageId));

                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                ms.Close();
                ms.Dispose();

                Image imgdata = new Image();
                if (result != null)
                {
                    result.ImageTitle = file.FileName;
                    result.ImageData = ms.ToArray();
                    result.Message = "Image Successfully updated.";
                    result.CreatedDate = DateTime.UtcNow;
                    _context.SaveChanges();
                }
                int id = imgdata.Id; // Yes it's here

                return Convert.ToString(id);
            }
            catch (Exception e)
            {
                img.Id = -1;
                img.Message = "Image Could Not Be Updated. Error: " + e.ToString();
                return Convert.ToString(-1);
            }
        }
    }
}