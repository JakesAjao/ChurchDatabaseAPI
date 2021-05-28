using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchDatabaseAPI.Request
{
    public class MemberUpdateRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Prefix { get; set; }
        public string Sex { get; set; }
        public string Status { get; set; }
        public string MobilePhone1 { get; set; }
        public string MobilePhone2 { get; set; }
        public string HomePhone { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string NextOfKin { get; set; }
        public string DateOfBirth { get; set; }
        public string Age { get; set; }
        public string WeddingAnniversary { get; set; }
        public string Profession { get; set; }
        public string PrayerRequest { get; set; }
        public string SendNewLetter { get; set; }
        public int ImageForeignKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Member { get; set; }
        public string Interest { get; set; }
    }
}
