using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ChurchDatabaseAPI.Model;
using ChurchDatabaseAPI.Response;
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
        [EnableCors("AllowAllHeaders")]
        public UploadResponseData UploadFile([FromForm]IFormFile file)
        {
            UploadResponseData rspData = new UploadResponseData();
            if (file == null)
            {
                rspData.ImageId = -1; //
                rspData.Status = false; //
                rspData.Message = "Empty file input."; //
                return rspData;
            }
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
                rspData.ImageId  = imgdata.Id; //
                rspData.Status = true; //
                rspData.Message = "Upload successful."; //

                return rspData;
            }
            catch (Exception e)
            {
                rspData.ImageId = -1; //
                rspData.Status = false; //
                rspData.Message = "Upload failed. Error: " + e.ToString();
                return rspData;
            }
        }
        [HttpPost("updatephoto")]
        [EnableCors("AllowAllHeaders")]
        public UploadResponseData UpdateFile([FromForm]IFormFile file, [FromForm]String imageId)
        {
            Image img = new Image();
            UploadResponseData rspData = new UploadResponseData();
            if (file == null)
            {
                rspData.ImageId = -1; //
                rspData.Status = false; //
                rspData.Message = "Empty file input."; //
                return rspData;
            }
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
                rspData.ImageId = imgdata.Id; //
                rspData.Status = true; //
                rspData.Message = "Image Successfully updated."; //

                return rspData;
            }
            catch (Exception e)
            {
                rspData.ImageId = -1; //
                rspData.Status = false; //
                rspData.Message = "Image updated failed. Exception: "+e.ToString(); //
                return rspData;
            }
        }
    }
}