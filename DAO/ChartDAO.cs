using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchDatabaseAPI.DAO
{
    public class ChartDAO
    {
        //Jakes
        public static int[] GetXXPerMonthList(ApplicationDatabaseContext _context, string searchKey, string _year)
        {
            try
            {
                string year = "";
                year = _year;
                int AugCount = (from result
              in _context.Membership.AsEnumerable()
                                where result.Interest == searchKey && result.CreatedDate >= Convert.ToDateTime(year + "-08-01") && result.CreatedDate <= Convert.ToDateTime(year + "-08-31")
                                select result).Count();
                int janCount = (from result
                     in _context.Membership.AsEnumerable()
                                where result.Interest == searchKey && result.CreatedDate >= Convert.ToDateTime(year + "-01-01") && result.CreatedDate <= Convert.ToDateTime(year + "-01-31")
                                select result).Count();

                int FebCount = 0;
                int yearInt = Convert.ToInt32(year);
                if (yearInt % 4 == 0)
                {
                    FebCount = (from result
                                        in _context.Membership.AsEnumerable()
                                where result.Interest == searchKey && result.CreatedDate >= Convert.ToDateTime(year + "-02-01") && result.CreatedDate <= Convert.ToDateTime(year + "-02-29")
                                select result).Count();
                }
                else
                {
                    FebCount = (from result
                                        in _context.Membership.AsEnumerable()
                                where result.Interest == searchKey && result.CreatedDate >= Convert.ToDateTime(year + "-02-01") && result.CreatedDate <= Convert.ToDateTime(year + "-02-28")
                                select result).Count();

                }

                int MarCount = (from result
                    in _context.Membership.AsEnumerable()
                                where result.Interest == searchKey && result.CreatedDate >= Convert.ToDateTime(year + "-03-01") && result.CreatedDate <= Convert.ToDateTime(year + "-03-31")
                                select result).Count();

                int AprCount = (from result
                in _context.Membership.AsEnumerable()
                                where result.Interest == searchKey && result.CreatedDate >= Convert.ToDateTime(year + "-04-01") && result.CreatedDate <= Convert.ToDateTime(year + "-04-30")
                                select result).Count();
                int MayCount = (from result
                    in _context.Membership.AsEnumerable()
                                where result.Interest == searchKey && result.CreatedDate >= Convert.ToDateTime(year + "-05-01 ") && result.CreatedDate <= Convert.ToDateTime(year + "-05-31")
                                select result).Count();
                int JunCount = (from result
                   in _context.Membership.AsEnumerable()
                                where result.Interest == searchKey && result.CreatedDate >= Convert.ToDateTime(year + "-06-01") && result.CreatedDate <= Convert.ToDateTime(year + "-06-30")
                                select result).Count();

                int JulCount = (from result
                    in _context.Membership.AsEnumerable()
                                where result.Interest == searchKey && result.CreatedDate >= Convert.ToDateTime(year + "-07-01") && result.CreatedDate <= Convert.ToDateTime(year + "-07-31")
                                select result).Count();

                int SepCount = (from result
                    in _context.Membership.AsEnumerable()
                                where result.Interest == searchKey && result.CreatedDate >= Convert.ToDateTime(year + "-09-01") && result.CreatedDate <= Convert.ToDateTime(year + "-09-30")
                                select result).Count();
                int OctCount = (from result
                in _context.Membership.AsEnumerable()
                                where result.Interest == searchKey && result.CreatedDate >= Convert.ToDateTime(year + "-10-01") && result.CreatedDate <= Convert.ToDateTime(year + "-10-31")
                                select result).Count();
                int NovCount = (from result
                   in _context.Membership.AsEnumerable()
                                where result.Interest == searchKey && result.CreatedDate >= Convert.ToDateTime(year + "-11-01") && result.CreatedDate <= Convert.ToDateTime(year + "-11-30")
                                select result).Count();

                int DecCount = (from result
                in _context.Membership.AsEnumerable()
                                where result.Interest == searchKey && result.CreatedDate >= Convert.ToDateTime(year + "-12-01") && result.CreatedDate <= Convert.ToDateTime(year + "-12-31")
                                select result).Count();

                int[] chartArr = { janCount, FebCount, MarCount, AprCount, MayCount, JunCount, JulCount, AugCount, SepCount, OctCount, NovCount, DecCount };

                return chartArr;
            }
            catch (Exception e)
            {
                int[] chartArr2 = { };
                return chartArr2;

            }

        }

    }
}
