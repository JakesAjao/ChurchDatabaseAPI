using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchDatabaseAPI.Model
{
    public class Crypt
    {
        public string Request { get; set; }
        public string Data { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
