using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchDatabaseAPI.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChurchDatabaseAPI.Controllers
{
    [Route("churchdatabaseapi/user")]
    [EnableCors("AllowAllHeaders")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ApplicationDatabaseContext _context;
        public UserController(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        // GET: api/User Details
        [HttpGet]
        [EnableCors("AllowAllHeaders")]
        public async Task<ActionResult<IEnumerable<User>>> UserDetails()
        {
            return await _context.User.ToListAsync();
        }
        [HttpPost("adduser")]
        public User AddUser(User userData)
        {
            try
            {
                User user = new User();
                //User userData = JsonConvert.DeserializeObject<User>(userRequest);
                Console.WriteLine(userData.FirstName);

                user.FirstName = userData.FirstName;
                user.Surname = userData.Surname;
                user.Username = userData.Username;
                user.Password = new Utility().EnCryptKey1(userData.Password);
                user.Status = userData.Status;
                user.Email = userData.Email;
                user.CreatedDate = DateTime.UtcNow;
                user.Role = userData.Role;
                user.Message = "";

                _context.User.Add(user);
                _context.SaveChanges();
                userData.Message = "User Created Successfully.";
                int id = user.Id; // Yes it's here
                Console.WriteLine(id);
                if (id > 0)
                    return userData;
            }
            catch (Exception e)
            {
                User user = new User();
                user.FirstName = userData.FirstName;
                user.Surname = userData.Surname;
                user.Username = userData.Username;
                user.Password = userData.Password;
                user.Status = userData.Status;
                user.Email = userData.Email;
                user.CreatedDate = DateTime.UtcNow;
                user.Role = userData.Role;
                user.Message = "Exception: Username or Email already exist.";
                return user;
            }
            return userData;
        }

        [HttpPost("getuser")]
        public User GetUser(UserFilter userFilter)
        {
            try
            {
                string encryptPassword = new Utility().EnCryptKey1(userFilter.Password);
                var user = _context.User
                   .Where(b => b.Username == userFilter.Username && b.Password == encryptPassword)
                   .FirstOrDefault();
                if (user != null)
                {
                    User userResponse = new User();
                    userResponse.Password = new Utility().DeCryptKey1(encryptPassword);
                    userResponse.Username = user.Username;
                    userResponse.Role = user.Role;
                    userResponse.Status = user.Status;
                    userResponse.Surname = user.Surname;
                    userResponse.FirstName = user.FirstName;
                    userResponse.Email = user.Email;
                    userResponse.CreatedDate = user.CreatedDate;
                    return userResponse;
                }
            }
            catch (Exception e)
            {
                User user2 = new User();
                user2.Message = "Exception: "+e.ToString();
                return user2;
            }
            User user1 = new User();
            user1.Message = "User does not exist.";

            return user1;
        }

        [HttpPost("edituser")]
        public User EditUser(User user)
        {
            if (!UserExists(user.Id))
            {
                user.Message = "Sorry, user not found.";
                return user;
            }
            if (user.Password != null)
            {
                _context.Entry(user).Property(x => x.Password).IsModified = true;
            }
            if (user.Status != null)
            {
                _context.Entry(user).Property(x => x.Status).IsModified = true;
            }
            if (user.Role != null)
            {
                _context.Entry(user).Property(x => x.Role).IsModified = true;
            }
            if (user.Surname != null)
            {
                _context.Entry(user).Property(x => x.Surname).IsModified = true;
            }
            if (user.FirstName != null)
            {
                _context.Entry(user).Property(x => x.FirstName).IsModified = true;
            }
            if (user.Email != null)
            {
                _context.Entry(user).Property(x => x.Email).IsModified = true;
            }

            try
            {
                _context.SaveChanges();
                user.Message = "User updated successfully.";
                return user;
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!UserExists(user.Id))
                {
                    user.Message = "User update failed. Exception: " + e.ToString();
                }
                else
                {
                    throw;
                }
            }
            return user;
        }
        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
        // DELETE: api/User/5
        [HttpDelete("delete/id={id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            try
            {
                var user = await _context.User.FindAsync(id);
                if (user == null)
                {
                    User user1 = new User();
                    user1.Message = "User deletion failed.";

                    return user1;
                }

                _context.User.Remove(user);
                await _context.SaveChangesAsync();

                user.Message = "User deleted successfully.";

                return user;
            }
            catch (Exception e)
            {
                User user1 = new User();
                user1.Message = "Exception: " + e.ToString();
                return user1;
            }
        }
        [HttpPost("decrypt")]
        public Crypt Decrypt(Crypt crypt)
        {
            try
            {
                if (crypt.Request != null)
                {
                    string decryptedPWD = new Utility().DeCryptKey1(crypt.Request);
                    crypt.Data = decryptedPWD;
                    crypt.Status = true;
                    crypt.Message = "Successful";
                    return crypt;
                }
                else
                {
                    crypt.Data = "";
                    crypt.Status = false;
                    crypt.Message = "Failed";
                    return crypt;
                }
            }
            catch (Exception e)
            {
                crypt.Data = "";
                crypt.Status = false;
                crypt.Message = e.ToString();
                crypt.Data = "";
                return crypt;
            }
            return null;
        }
    }
}