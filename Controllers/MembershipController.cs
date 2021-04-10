using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ChurchDatabaseAPI.DAO;
using ChurchDatabaseAPI.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChurchDatabaseAPI.Controllers
{
    [Route("churchdatabaseapi/membership")]
    [EnableCors("AllowAllHeaders")]
    [ApiController]

    //GetMemberByStartEndDate
    //GetNoOfGender
    //filtermember
    //addmember
    //getgendertotal
    //updatemember
    //deleteall
    //ValidateEmail
    //GetMember
    public class MembershipController : ControllerBase
    {
        private readonly ApplicationDatabaseContext _context;
        public MembershipController(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        // GET: api/Membership Details

        //[EnableCors("AllowAllHeaders")]
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Membership>>> MembershipDetails()
        //{
        //    return await _context.Membership.ToListAsync();
        //}
        //GET: api/Membership
        [HttpGet("memberdetails")]
        [EnableCors("AllowAllHeaders")]       
        public async Task<ActionResult<IEnumerable<Membership>>> MemberDetails()
        {
            return await _context.Membership.ToListAsync();
        }
        [HttpPost("getmember")]
        public async Task<ActionResult<Object>> GetMember(MemberFilter memberFilter)
        {
            try
            {
                //var member = _context.Membership.First(a => a.FirstName == firstName || a.LastName == lastName || a.MiddleName == middleName);
                ////Get ImageData/Photo
                //int memberForeignKey = member.ImageForeignKey;
                //var image = _context.Image.First(a => a.Id == memberForeignKey);

                //return member;
                //if (member == null)
                //{
                //    return NotFound();
                //}

                var member = (from p in _context.Membership
                              join e in _context.Image
                              on p.ImageForeignKey equals e.Id
                              where p.FirstName == memberFilter.FirstName || p.LastName == memberFilter.LastName || p.MiddleName == memberFilter.MiddleName
                              select new
                              {
                                  ID = p.Id,
                                  FirstName = p.FirstName,
                                  MiddleName = p.MiddleName,
                                  LastName = p.LastName,
                                  Prefix = p.Prefix,
                                  Sex = p.Sex,
                                  Status = p.Status,
                                  MobilePhone1 = p.MobilePhone1,
                                  MobilePhone2 = p.MobilePhone2,
                                  HomePhone = p.HomePhone,
                                  EmailAddress = p.EmailAddress,
                                  Address = p.Address,
                                  NextOfKin = p.NextOfKin,
                                  DateOfBirth = p.DateOfBirth,
                                  Age = p.Age,
                                  WeddingAnniversary = p.WeddingAnniversary,
                                  Profession = p.Profession,
                                  PrayerRequest = p.PrayerRequest,
                                  SendNewLetter = p.SendNewLetter,
                                  CreatedDate = p.CreatedDate,
                                  ImageData = e.ImageData,
                                  ImageTitle = e.ImageTitle

                              }).ToList();
                return member;
            }
            catch (Exception e)
            {
            }
            return null;
        }
        [HttpPost("addmember")]
        public string AddMember(Membership membershipData)
        {
            try
            {
                Membership member = new Membership();
               // Membership membershipData = JsonConvert.DeserializeObject<Membership>(membershipRequest);
                Console.WriteLine(membershipData.Address);
                member.Address = membershipData.Address;
                member.Age = membershipData.Age;
                member.DateOfBirth = membershipData.DateOfBirth;
                member.EmailAddress = membershipData.EmailAddress;
                member.FirstName = membershipData.FirstName;
                member.HomePhone = membershipData.HomePhone;
                //member.Id = membershipData.Id;
                //Image img = new Image() { };
                //member.Image = img;
                member.ImageForeignKey = membershipData.ImageForeignKey;
                member.LastName = membershipData.LastName;
                member.MiddleName = membershipData.MiddleName;
                member.MobilePhone1 = membershipData.MobilePhone1;
                member.MobilePhone2 = membershipData.MobilePhone2;
                member.NextOfKin = membershipData.NextOfKin;
                member.PrayerRequest = membershipData.PrayerRequest;
                member.Prefix = membershipData.Prefix;
                member.Profession = membershipData.Profession;
                member.SendNewLetter = membershipData.SendNewLetter;
                member.Sex = membershipData.Sex;
                member.Status = membershipData.Status;
                member.WeddingAnniversary = membershipData.WeddingAnniversary;
                member.CreatedDate = DateTime.UtcNow;
                member.Interest = membershipData.Interest;
                Console.WriteLine(membershipData.LastName);

                _context.Membership.Add(member);
                _context.SaveChanges();
                //membershipData.Message = "Member Created Successfully.";
                int id = member.Id; // Yes it's here
                Console.WriteLine(id);
                if (id > 0)
                    return "Member Created Successfully.";
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return "Member could not be added.";
        }
        [HttpGet("getgendertotal")]
        [EnableCors("AllowAllHeaders")]
        public String GetNoOfGender()
        {
            try
            {
                var member = (from r in _context.Membership select r);
                int maleCounter = 0;
                int femaleCounter = 0;

                Dictionary<String, int> map = new Dictionary<String, int>();

                foreach (var obj in member)
                {
                    if (obj.Sex == "Male")
                    {
                        ++maleCounter;
                    }
                    else
                    {
                        ++femaleCounter;
                    }
                }
                map.Add("Male", maleCounter);
                map.Add("Female", femaleCounter);

                String mapJSON = JsonConvert.SerializeObject(map);
                Console.WriteLine("mapJSON: " + mapJSON);
                return mapJSON;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }
        [HttpPost("filtermember")]
        [EnableCors("AllowAllHeaders")]
        public async Task<ActionResult<IEnumerable<Membership>>> GetMemberByStartEndDate(DateFilter datefilter)
        {
            try
            {
                if (datefilter != null)
                {
                    DateTime _startDate = Convert.ToDateTime(datefilter.startDate);
                    DateTime _endDate = Convert.ToDateTime(datefilter.endDate);
                    string sex = datefilter.gender;
                    string status = datefilter.status;
                    string interest = datefilter.interest;
                    if (datefilter.interest == "Member only")
                    {
                        interest = "Yes";
                    }
                    else if (datefilter.interest == "Non-Member only"){
                        interest = "No";
                    }
                    else//All members
                    {

                    }
                    if ((datefilter.interest == "All members") || (datefilter.status == "" && datefilter.gender == "" && datefilter.interest == ""))
                    {
                        var filteredMember = _context.Membership.Where(t => t.CreatedDate >= _startDate && t.CreatedDate <= _endDate);
                        return await filteredMember.ToListAsync();
                    }
                    else if ((datefilter.interest != "All members") && (sex != "") && (interest != ""))
                    {
                        var filteredMember = _context.Membership.Where(t => t.CreatedDate >= _startDate && t.CreatedDate <= _endDate &&
                          t.Status == status && t.Sex == sex && t.Interest == interest);
                        return await filteredMember.ToListAsync();
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [HttpPut("{id}")]
        [EnableCors("AllowAllHeaders")]
        public async Task<IActionResult> PutMember(int id, Membership member)
        {
            if (id != member.Id)
            {
                return BadRequest();
            }

            _context.Entry(member).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        private bool MemberExists(int id)
        {
            return _context.Membership.Any(e => e.Id == id);
        }
        [HttpGet("validate/email={email}")]
        [EnableCors("AllowAllHeaders")]
        public bool ValidateEmail(String email)
        {
            Membership myUser = _context.Membership.FirstOrDefault
              (u => u.EmailAddress.Equals(email));

            if (myUser != null)
            {
                return true;
            }
            else    //User was not found
            {
                return false;
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Membership>> DeleteMember(int id)
        {
            var member = await _context.Membership.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            _context.Membership.Remove(member);
            await _context.SaveChangesAsync();

            return member;
        }
        [HttpGet("deleteall")]
        [EnableCors("AllowAllHeaders")]
        [Microsoft.AspNetCore.Mvc.HttpDelete]
        public int DeleteAllMembers()
        {
            //int itemsToDelete2 = _context.Database.ExecuteSqlRaw("TRUNCATE TABLE [Image]");
            // _context.SaveChanges();
            int itemsToDelete = _context.Database.ExecuteSqlRaw("DELETE FROM Membership DBCC CHECKIDENT('ChurchInformationSystemDB.dbo.Membership', RESEED, 0)");

            _context.SaveChanges();

            return itemsToDelete;
        }
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
        [HttpPost("updatemember")]
        [EnableCors("AllowAllHeaders")]
        public Membership UpdateMember([FromForm]String memberData)
        {
            Membership member = JsonConvert.DeserializeObject<Membership>(memberData);
            if (!MemberExists(member.Id))
            {
                //member.Message = "Not Found";
                return member;
            }
            if (member.MobilePhone1 != null)
            {
                _context.Entry(member).Property(x => x.MobilePhone1).IsModified = true;
            }
            if (member.MobilePhone2 != null)
            {
                _context.Entry(member).Property(x => x.MobilePhone2).IsModified = true;
            }
            if (member.HomePhone != null)
            {
                _context.Entry(member).Property(x => x.HomePhone).IsModified = true;
            }
            if (member.FirstName != null)
            {
                _context.Entry(member).Property(x => x.FirstName).IsModified = true;
            }
            if (member.LastName != null)
            {
                _context.Entry(member).Property(x => x.LastName).IsModified = true;
            }
            if (member.MiddleName != null)
            {
                _context.Entry(member).Property(x => x.MiddleName).IsModified = true;
            }
            if (member.Address != null)
            {
                _context.Entry(member).Property(x => x.Address).IsModified = true;
            }
            if (member.EmailAddress != null)
            {
                _context.Entry(member).Property(x => x.EmailAddress).IsModified = true;
            }
            if (member.NextOfKin != null)
            {
                _context.Entry(member).Property(x => x.NextOfKin).IsModified = true;
            }
            if (member.Member != null)
            {
                _context.Entry(member).Property(x => x.Member).IsModified = true;
            }
            if (member.Sex != null)
            {
                _context.Entry(member).Property(x => x.Sex).IsModified = true;
            }
            if (member.Prefix != null)
            {
                _context.Entry(member).Property(x => x.Prefix).IsModified = true;
            }
            if (member.Profession != null)
            {
                _context.Entry(member).Property(x => x.Profession).IsModified = true;
            }
            if (member.SendNewLetter != null)
            {
                _context.Entry(member).Property(x => x.SendNewLetter).IsModified = true;
            }
            if (member.WeddingAnniversary != null)
            {
                _context.Entry(member).Property(x => x.WeddingAnniversary).IsModified = true;
            }

            try
            {
                _context.SaveChanges();
                //member.Message = "Successfully updated";
                return member;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(member.Id))
                {
                    // member.Message = "NotFound";
                }
                else
                {
                    throw;
                }
            }
            //member.Message = "No Content";
            return member;
        }
        [HttpGet("validate/mobilephone={mobilephone}")]
        [EnableCors("AllowAllHeaders")]
        public bool ValidateMobilePhoneNo(String mobilephone)
        {
            Validate val = new Validate();
            if (val.IsMobilephone1Exists(_context, mobilephone) || val.IsMobilephone2Exists(_context, mobilephone) || val.IsHomephoneExists(_context, mobilephone))
            {
                return true;
            }
            else    //User was not found
            {
                return false;
            }
        }
        [HttpGet("id={id}")]
        [EnableCors("AllowAllHeaders")]
        public async Task<ActionResult<Membership>> GetMember(string id)
        {
            long Id = Convert.ToInt64(id);
            var member = _context.Membership.First(a => a.Id == Id);
            //Get ImageData/Photo
            int memberForeignKey = member.ImageForeignKey;
            var image = _context.Image.First(a => a.Id == memberForeignKey);
            member.Image = image;

            if (member == null)
            {
                return NotFound();
            }

            return member;
        }
    }

}
