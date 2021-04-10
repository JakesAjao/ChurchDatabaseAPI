using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchDatabaseAPI.DAO;
using ChurchDatabaseAPI.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ChurchDatabaseAPI.Controllers
{
    [Route("churchdatabaseapi")]
    [EnableCors("AllowAllHeaders")]
    [ApiController]
    public class ChartsController : Controller
    {
        private readonly ApplicationDatabaseContext _context;
        public ChartsController(ApplicationDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("charts/totalnewmembersvisitorpermonth/year={year}")]
        [EnableCors("AllowAllHeaders")]
        public string NewMemberVisitorsPerMonthAPI(string year)
        {
            string newMemberVisitorPerMonthsList = ProcessNewMembersVisitorsPerMonthList(year);
            return newMemberVisitorPerMonthsList;
        }
        [HttpGet("charts/totalvisitorspermonth/year={year}")]
        [EnableCors("AllowAllHeaders")]
        public string TotalVisitorsPerMonth(string year)
        {
            string visitorPerMonthsList = ProcessVisitorsPerMonthList(year);
            return visitorPerMonthsList;
        }
        private string ProcessNewMembersVisitorsPerMonthList(string year)
        {

            try
            {
                //string year = DateTime.Now.ToString("yyyy");
                int[] newArrMembers = ChartDAO.GetXXPerMonthList(_context, "Yes", year);
                int[] newVisitorsArr = ChartDAO.GetXXPerMonthList(_context, "No", year);

                List<Chart> chartList = new List<Chart> { new Chart { data = newArrMembers, label = "Joined Member" },
                                                          new Chart { data = newVisitorsArr, label = "Visitors" } };

                string joinedMemberJson = JsonConvert.SerializeObject(chartList);
                return joinedMemberJson;

            }
            catch (Exception e)
            {
                return "ProcessNewMembersVisitorsPerMonthList Exception: " + e.ToString();
            }
        }

        private string ProcessVisitorsPerMonthList(string year)
        {
            try
            {
                int[] newVisitorsArr = ChartDAO.GetXXPerMonthList(_context, "No", year);

                List<Chart> chartList = new List<Chart> { new Chart { data = newVisitorsArr, label = "Visitors" } };

                string joinedVisitorsJson = JsonConvert.SerializeObject(chartList);
                return joinedVisitorsJson;

            }
            catch (Exception e)
            {
                return "ProcessVisitorsPerMonthList Exception: " + e.ToString();
            }
        }
    }
}