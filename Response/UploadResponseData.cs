using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchDatabaseAPI.Response
{
    public class UploadResponseData
    {
        public int ImageId { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
    }

}
