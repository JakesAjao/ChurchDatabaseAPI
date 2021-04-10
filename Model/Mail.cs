using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchDatabaseAPI.Model
{
    public class Mail
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public string emailAddress { get; set; }//toAddress
        public string subject { get; set; }
        public string body { get; set; }
        public string searchKey { get; set; }//MembersOnly/VisitorsOnly/All
        public string mobilePhone { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime responseTime { get; set; }
        public string status { get; set; } //200
        public string statusMessage { get; set; } //Error or Success msg
        public string serviceType { get; set; }//Email/SMS //exlude Minor in the script
        public string fileName { get; set; }
    }
    public class EmailRequest
    {
        public string body { get; set; }
        public string searchKey { get; set; }
        public string subject { get; set; }
        public string emailAddress { get; set; }
        public string serviceType { get; set; }
        public int requestId { get; set; }
        public string mobilephone { get; set; }
    }
}
