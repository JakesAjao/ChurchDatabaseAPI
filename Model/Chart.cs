using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchDatabaseAPI.Model
{
    public class Chart
    {
        public int Id { get; set; }
        public int[] data { get; set; }
        public string label { get; set; }
        //public string Message { get; set; }
        //public bool flag { get; set; }
    }
}
