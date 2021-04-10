using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchDatabaseAPI.DAO
{
    public class Validate
    {
        public bool IsMobilephone1Exists(ApplicationDatabaseContext _context, string mobilephone)
        {
            return _context.Membership.Any(e => e.MobilePhone1 == mobilephone);
        }
        public bool IsMobilephone2Exists(ApplicationDatabaseContext _context, string mobilephone)
        {
            return _context.Membership.Any(e => e.MobilePhone2 == mobilephone);
        }
        public bool IsHomephoneExists(ApplicationDatabaseContext _context, string mobilephone)
        {
            return _context.Membership.Any(e => e.HomePhone == mobilephone);
        }
    }
}
