using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchDatabaseAPI.Response
{
    public class AddMemberResponse
    {
        public string Exception { get; set; }
        public int MemberId { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
