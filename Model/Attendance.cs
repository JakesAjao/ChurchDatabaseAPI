using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchDatabaseAPI.Model
{
    public class Attendance
    {
        public int Id { get; set; }
        public Boolean Status { get; set; }
        public string EventDate { get; set; }
    }
}
