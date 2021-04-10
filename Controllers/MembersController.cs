using ChurchDatabaseAPI.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchDatabaseAPI.Controllers
{
    [Route("churchdatabaseapi")]
    [EnableCors("AllowAllHeaders")]
   
    [ApiController]
    //GetMemberByStartEndDate
    //GetNoOfGender
    //getGenderTotal
    //id
    public class MemberController : ControllerBase
    {
        private readonly ApplicationDatabaseContext _context;

        public MemberController(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        ////Get total number of Gender
        ////jakes
        //[HttpGet("getGenderTotal")] It was gender before
        //[EnableCors("AllowAllHeaders")]
        //public String GetNoOfGender()
        //{
        //    try
        //    {
        //        var member = (from r in _context.Member select r);
        //        int maleCounter = 0;
        //        int femaleCounter = 0;
        //        int minorCounter = 0;

        //        Dictionary<String, int> map = new Dictionary<String, int>();

        //        foreach (var obj in member)
        //        {
        //            if (obj.Gender == "Male")
        //            {
        //                ++maleCounter;
        //            }
        //            else if (obj.Gender == "Female")
        //            {
        //                ++femaleCounter;
        //            }
        //            else
        //            {
        //                ++minorCounter;
        //            }
        //        }
        //        map.Add("Male", maleCounter);
        //        map.Add("Female", femaleCounter);
        //        map.Add("Minor", minorCounter);

        //        String mapJSON = JsonConvert.SerializeObject(map);
        //        Console.WriteLine("mapJSON: " + mapJSON);
        //        return mapJSON;
        //    }
        //    catch(Exception e)
        //    {
        //        Console.WriteLine(e);
        //    }
        //    return null;
        //}

        //[HttpPost("filtermember")]
        //[EnableCors("AllowAllHeaders")]
        //public async Task<ActionResult<IEnumerable<Member>>> GetMemberByStartEndDate(DateFilter datefilter)
        //{
        //    try
        //    {
        //        if (datefilter != null)
        //        {
        //            DateTime _startDate = Convert.ToDateTime(datefilter.startDate);
        //            DateTime _endDate = Convert.ToDateTime(datefilter.endDate);

        //            string status = "no";
        //            if (datefilter.status == "Member")
        //            {
        //                status = "Yes";
        //            }
        //            if (datefilter.status == "Non-Member")
        //            {
        //                status = "No";
        //            }
        //            if (datefilter.status == null && datefilter.gender == null)
        //            {
        //                var filteredMember = _context.Member.Where(t => t.CreatedDate >= _startDate && t.CreatedDate <= _endDate);
        //                return await filteredMember.ToListAsync();
        //            }
        //            else
        //            {
        //                var filteredMember = _context.Member.Where(t => t.CreatedDate >= _startDate && t.CreatedDate <= _endDate &&
        //                t.Gender == datefilter.gender && t.Join == status);
        //                return await filteredMember.ToListAsync();
        //            }
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    catch(Exception e)
        //    {
        //        return null;
        //    }
        //}

        //// GET: api/Member
        //[HttpGet]
        //[EnableCors("AllowAllHeaders")]
        //public async Task<ActionResult<IEnumerable<Member>>> GetMember()
        //{
        //    return await _context.Member.ToListAsync();
        //}

        //// GET: api/GetMember/by Member Name Jakes Commented
        ////[HttpGet("{name}")]
        ////public async Task<ActionResult<Member>> GetMember(string name)
        ////{
        ////    var member =_context.Member.First(a => a.MemberName == name);
        ////    //Get ImageData/Photo
        ////    int memberForeignKey = member.Id;
        ////    var image = _context.Image.First(a => a.MemberForeignKey == memberForeignKey);
        ////   // member.Image = image;//Jakes commented

        ////    if (member == null)
        ////    {
        ////        return NotFound();
        ////    }

        ////    return member;
        ////}

        //// PUT: api/Member/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //[EnableCors("AllowAllHeaders")]
        //public async Task<IActionResult> PutMember(int id, Member member)
        //{
        //    if (id != member.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(member).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MemberExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //    return NoContent();
        //}

        //// POST: api/Member
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<Member>> PostMember([FromForm]IFormFile file,[FromForm]String memberData)
        //{
        //    Member myObj = JsonConvert.DeserializeObject<Member>(memberData);
        //    Console.WriteLine(myObj.MemberName);
        //    Image img = new Image();
        //    img.ImageTitle = file.FileName;
        //    MemoryStream ms = new MemoryStream();
        //    file.CopyTo(ms);
        //    img.ImageData = ms.ToArray();

        //    ms.Close();
        //    ms.Dispose();

        //    //myObj.Image = img; Jakes commented

        //    _context.Member.Add(myObj);
        //    await _context.SaveChangesAsync();
        //    myObj.Message = "Successfully Created Member";

        //    return CreatedAtAction("GetMember", new { id = myObj.Id }, myObj);
        //}
        //[HttpGet("validate/member/phonenumber={phonenumber}")]
        //[EnableCors("AllowAllHeaders")]
        //public bool ValidateMemberPhoneNumber(string phonenumber)
        //{
        //    Member myUser = _context.Member.FirstOrDefault
        //      (u => u.PhoneNumber.Equals(phonenumber));
        //    if (myUser != null)
        //    {
        //        return true;
        //    }
        //    else    //User was not found
        //    {
        //        return false;
        //    }
        //}
        //[HttpGet("validate/member/email={email}")]
        //[EnableCors("AllowAllHeaders")]
        //public bool ValidateMemberEmail(String email)
        //{
        //    Member myUser = _context.Member.FirstOrDefault
        //      (u => u.Email.Equals(email));

        //    if (myUser != null)
        //    {
        //        return true;
        //    }
        //    else    //User was not found
        //    {
        //        return false;
        //    }
        //}

        //// DELETE: api/Member/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Member>> DeleteMember(int id)
        //{
        //    var member = await _context.Member.FindAsync(id);
        //    if (member == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Member.Remove(member);
        //    await _context.SaveChangesAsync();

        //    return member;
        //}
        //// DELETE: api/Member/5
        //[HttpGet("deleteall")]
        //[EnableCors("AllowAllHeaders")]
        //public int DeleteAllMember()
        //{
        //    //int itemsToDelete2 = _context.Database.ExecuteSqlRaw("TRUNCATE TABLE [Image]");
        //   // _context.SaveChanges();
        //    int itemsToDelete = _context.Database.ExecuteSqlRaw("DELETE FROM Member DBCC CHECKIDENT('ChurchInformationSystemDB.dbo.Member', RESEED, 0)");

        //    _context.SaveChanges();

        //    return itemsToDelete;
        //}
        //[HttpPost("uploadphoto")]
        //public Image UploadFile([FromForm]IFormFile file, [FromForm]String memberData)
        //{
        //    //memberData  
        //    JObject obj = JObject.Parse(memberData);
        //    string memberForeignKey = (string)obj["memberForeignKey"];
        //    Console.WriteLine(memberForeignKey);
        //    Image img = new Image();
        //    try
        //    {
        //        ///img.ImageTitle = file.FileName;
        //        int MemberForeignKey = Convert.ToInt32(memberForeignKey);
        //        //img.ImageId = imageId;

        //        MemoryStream ms = new MemoryStream();
        //        file.CopyTo(ms);
        //        //img.ImageData = ms.ToArray();

        //        ms.Close();
        //        ms.Dispose();
        //       //_context.Image.Add(img);

        //        var result = _context.Image.SingleOrDefault(b => b.MemberForeignKey == MemberForeignKey);
        //        if (result != null)
        //        {
        //            //Last eneterd Id
        //            //img.Id = img.Id;
        //            result.ImageTitle = file.FileName;
        //            result.ImageData = ms.ToArray();
        //            result.Message = "Image Successfully uploaded.";
        //            _context.Image.Add(result);
        //            _context.Image.Attach(result);
        //            _context.Entry(result).State = EntityState.Modified;
        //            _context.SaveChanges();
        //        }
        //        return img;
        //    }
        //    catch (Exception e)
        //    {
        //        img.Id = -1;
        //        img.Message = "Image Could Not Be uploaded. Error: " + e.ToString();
        //        return img;
        //    }
        //}
        //[HttpPost("updatemember")]
        //[EnableCors("AllowAllHeaders")]
        //public Member UpdateMember([FromForm]String memberData)
        //{
        //    Member member = JsonConvert.DeserializeObject<Member>(memberData);
        //   // Member member = new Member();
        //    if (!MemberExists(member.Id))
        //    {
        //        member.Message = "Not Found";
        //        return member;
        //    }
        //    if (member.PhoneNumber!=0)
        //    {
        //        _context.Entry(member).Property(x => x.PhoneNumber).IsModified = true;
        //    }
        //    if (member.MemberName != null)
        //    {
        //        _context.Entry(member).Property(x => x.MemberName).IsModified = true;
        //    }
        //    if (member.Address != null)
        //    {
        //        _context.Entry(member).Property(x => x.Address).IsModified = true;
        //    }
        //    if (member.Email != null)
        //    {
        //        _context.Entry(member).Property(x => x.Email).IsModified = true;
        //    }
        //    if (member.NextOfKin != null)
        //    {
        //        _context.Entry(member).Property(x => x.NextOfKin).IsModified = true;
        //    }
        //    if (member.Join != null)
        //    {
        //        _context.Entry(member).Property(x => x.Join).IsModified = true;
        //    }
        //    if (member.Gender != null)
        //    {
        //        _context.Entry(member).Property(x => x.Gender).IsModified = true;
        //    }

        //    try
        //    {
        //         _context.SaveChanges();
        //        member.Message = "Successfully updated";
        //        return member;
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MemberExists(member.Id))
        //        {
        //            member.Message = "NotFound";
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //    member.Message = "No Content";
        //    return member;
        //}

        //private bool MemberExists(int id)
        //{
        //    return _context.Member.Any(e => e.Id == id);
        //}

    }
}
