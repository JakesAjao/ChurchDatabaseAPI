using ChurchDatabaseAPI.Model;
using ChurchDatabaseAPI.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchDatabaseAPI.Controllers
{
    [Route("churchdatabaseapi/attendance")]
    [EnableCors("AllowAllHeaders")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly ApplicationDatabaseContext _context;
        public AttendanceController(ApplicationDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("details")]
        [EnableCors("AllowAllHeaders")]
        public async Task<ActionResult<IEnumerable<Attendance>>> AttendanceDetails()
        {
            return await _context.Attendance.ToListAsync();
        }
        [HttpPost("add")]
        [EnableCors("AllowAllHeaders")]
        public AddMemberResponse AddAttendance(Attendance attendaceData)
        {
            AddMemberResponse response = new AddMemberResponse();
            try
            {
                Attendance attend = new Attendance();
                attend.Status = attendaceData.Status;
                attend.MemberId = attendaceData.MemberId;
                attend.EventDate = attendaceData.EventDate;

                _context.Attendance.Add(attend);
                _context.SaveChanges();
                int id = attend.Id; // Yes it's here
                Console.WriteLine(id);

                if (id > 0)
                {
                    response.Status = true;
                    response.Message = "Attendance Created Successfully.";
                    response.MemberId = id;

                    return response;
                }
                response.Status = false;
                response.Message = "Attendance Could Not Be Added.";
                response.MemberId = id;

                return response;
            }
            catch (Exception e)
            {
                response.Status = false;
                response.Message = "Attendance could not be added. ";
                response.MemberId = -1;
                response.Exception = e.ToString();

                return response;
            }
        }
        [HttpPost("update")]
        [EnableCors("AllowAllHeaders")]
        public AddMemberResponse Update(Attendance attend)
        {
            AddMemberResponse response = new AddMemberResponse();
            //Attendance member = JsonConvert.DeserializeObject<Attendance>(memberData);
            if (!MemberExists(attend.MemberId))
            {
                response.Status = false;
                response.Message = "Member does not exist.";
                response.MemberId = -1;
                return response;
            }
            if (attend.Status!=null)
            {
                _context.Entry(attend).Property(x => x.Status).IsModified = true;
            }
            else if (attend.MemberId != null)
            {
                _context.Entry(attend).Property(x => x.MemberId).IsModified = true;
            }
            else if (attend.EventDate != null)
            {
                _context.Entry(attend).Property(x => x.EventDate).IsModified =true;
            }
            try
            {
                _context.SaveChanges();
                response.Status = true;
                response.Message = "Updated successfully.";
                response.MemberId = attend.MemberId;
                return response;
            }
            catch (DbUpdateConcurrencyException) {             
                response.Status = false;
                response.Message = "Update failed.";
                response.MemberId = -1;
                return response;
            }
        }
        private bool MemberExists(int id)
        {
            return _context.Membership.Any(e => e.Id == id);
        }
    }


}
