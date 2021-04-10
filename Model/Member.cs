using ChurchDatabaseAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchDatabaseAPI
{
    public class Member
    {
        public int Id { get; set; }
        public string MemberName { get; set; }
        public long PhoneNumber { get; set; }

        public string Address { get; set; }
        public string Email { get; set; }
        //public byte[] Photo { get; set; }
        public string NextOfKin { get; set; }
        public string DateOfBirth { get; set; }
        public string Join { get; set; }
        public string Message { get; set; }
        public string PrayerRequest { get; set; }
        public DateTime CreatedDate { get; set; }
       // public Image Image { get; set; }
        public bool check { get; set; }
        public String Gender { get; set; }
        //Children or Adult
    }

    public class DateFilter
    {
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string gender{ get; set; }
        public string status { get; set; }
        public string interest { get; set; }
    }
}


