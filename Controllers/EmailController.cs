using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchDatabaseAPI.DAO;
using ChurchDatabaseAPI.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ChurchDatabaseAPI.Controllers
{
    [Route("churchdatabaseapi")]
    [EnableCors("AllowAllHeaders")]
    [ApiController]
    public class EmailController : Controller
    {
        private readonly ApplicationDatabaseContext _context;
        public EmailController(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        //jakes
        //[HttpPost("mail/sendmail")]
        //[EnableCors("AllowAllHeaders")]
        //public string SendMail([FromForm]String emailRequest, [FromForm]IFormFile file)
        //{
        //    //string response = MailDAO.SendMail(mailData, file);
        //    Mail mail = JsonConvert.DeserializeObject<Mail>(emailRequest);
        //    string insertResponse = "";
        //    if (mail.serviceType == "Email")
        //    {
        //        insertResponse = MailDAO.InsertMemberDetailsForEmailIntoDB(_context, emailRequest, file);
        //    }
        //    else//SMS
        //    {
        //        insertResponse = MailDAO.InsertMemberDetailsForSMSIntoDB(_context, emailRequest, file);
        //    }
        //    return insertResponse;
        //}
    }
}