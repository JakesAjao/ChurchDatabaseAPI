using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchDatabaseAPI.Model
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }

        public Membership Membership { get; set; }
        //public int MemberForeignKey { get; set; }
    }
}
