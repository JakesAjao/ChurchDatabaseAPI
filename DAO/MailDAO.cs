using ChurchDatabaseAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ChurchDatabaseAPI.DAO
{
    public class MailDAO
    {
        //jakes
        //public static string SendMail([FromForm]String emailData, IFormFile file)
        //{
        //    try
        //    {
        //        //To be used for Window service 
        //        Mail email = JsonConvert.DeserializeObject<Mail>(emailData);
        //        string fileName = file.FileName;
        //        MemoryStream ms = new MemoryStream();
        //        // Upload the file if less than 2 MB
        //        if (ms != null && ms.Length < 2097152)
        //        {
        //            file.CopyTo(ms);

        //            byte[] dataFile = ms.ToArray();

        //            ms.Close();
        //            ms.Dispose();

        //            MailMessage mail = new MailMessage();
        //            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        //            mail.From = new MailAddress("testjakes09@gmail.com");
        //            mail.To.Add(email.emailAddress);
        //            mail.Subject = email.subject;
        //            mail.Body = email.body;

        //            Attachment attachment;
        //            if (file.Length > 0)
        //            {
        //                attachment = new Attachment(file.FileName);
        //                mail.Attachments.Add(attachment);
        //            }

        //            SmtpServer.Port = 587;
        //            SmtpServer.Credentials = new System.Net.NetworkCredential("testjakes09@gmail.com", "restore@123");
        //            SmtpServer.EnableSsl = true;

        //            SmtpServer.Send(mail);

        //            return "Mail Sent Successfully.";
        //        }
        //        else if (ms != null && ms.Length > 2097152)
        //        {
        //            return "The file is too large.";
        //        }
        //        else// No file attachment
        //        {
        //            MailMessage mail = new MailMessage();
        //            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        //            mail.From = new MailAddress("testjakes09@gmail.com");
        //            mail.To.Add(email.emailAddress);//toAddress
        //            mail.Subject = email.subject;
        //            mail.Body = email.body;

        //            SmtpServer.Port = 587;
        //            SmtpServer.Credentials = new System.Net.NetworkCredential("testjakes09@gmail.com", "restore@123");
        //            SmtpServer.EnableSsl = true;

        //            SmtpServer.Send(mail);

        //            return "Mail Sent Successfully.";
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return "SendMail Window Exception: " + e;
        //    }
        //}
        //public static string InsertMemberDetailsForEmailIntoDB(ApplicationDatabaseContext _context, [FromForm]String emailRequest, IFormFile file)
        //{
        //    try
        //    {
        //        EmailRequest emailrequest = JsonConvert.DeserializeObject<EmailRequest>(emailRequest);
        //        var db = _context;
        //        List<Member> memberList = null;
        //        if (emailrequest.searchKey == "Visitors Only" && emailrequest.serviceType == "Email")
        //        {
        //            memberList = (from s in db.Member
        //                          where (s.Gender != "Children") & (s.Join == "No")
        //                          select s).ToList();
        //        }
        //        else if (emailrequest.searchKey == "Members Only" && emailrequest.serviceType == "Email")
        //        {
        //            memberList = (from s in db.Member
        //                          where (s.Gender != "Children") & (s.Join == "Yes")
        //                          select s).ToList();
        //        }
        //        else if (emailrequest.searchKey == "All" && emailrequest.serviceType == "Email")
        //        {
        //            memberList = (from s in db.Member
        //                          where (s.Gender != "Children")
        //                          select s).ToList();
        //        }
        //        else //send to singleMail
        //        {
        //            //memberList = (from s in db.Member
        //            //              where s.Email == emailrequest.emailAddress & (s.Gender != "Children")
        //            //              select s).ToList();
        //            Mail mail = new Mail();
        //            mail.emailAddress = emailrequest.emailAddress;
        //            mail.body = emailrequest.body;
        //            mail.subject = emailrequest.subject;
        //            mail.createdDate = DateTime.Now;
        //            mail.serviceType = emailrequest.serviceType;
        //            mail.RequestId = emailrequest.requestId;
        //            mail.searchKey = emailrequest.searchKey;
        //            if (file != null)
        //            {
        //                mail.fileName = file.FileName;
        //            }

        //            db.Mail.Add(mail);
        //            db.SaveChanges();
        //            return "Email Data Successfully Saved.";
        //        }

        //        foreach (var member in memberList)
        //        {
        //            Mail mail = new Mail();
        //            mail.emailAddress = member.Email;
        //            string mobilePhone = "234" + Convert.ToString(member.PhoneNumber);
        //            mail.mobilePhone = mobilePhone;
        //            mail.searchKey = emailrequest.searchKey;
        //            mail.body = emailrequest.body;
        //            mail.subject = emailrequest.subject;
        //            mail.createdDate = DateTime.Now;
        //            mail.serviceType = emailrequest.serviceType;
        //            mail.RequestId = emailrequest.requestId;
        //            if (file!=null)
        //            {
        //                mail.fileName = file.FileName;
        //            }

        //            db.Mail.Add(mail);
        //            db.SaveChanges();
        //        }
        //        return "Email Data Saved Successfully";
        //    }
        //    catch (Exception e)
        //    {
        //        return "InsertMemberDetailsIntoDB Email Exception: " + e;
        //    }
        //}
        //public static string InsertMemberDetailsForSMSIntoDB(ApplicationDatabaseContext _context, [FromForm]String emailRequest, IFormFile file)
        //{
        //    try
        //    {
        //        EmailRequest emailrequest = JsonConvert.DeserializeObject<EmailRequest>(emailRequest);
        //        var db = _context;
        //        List<Member> memberList = null;
        //        if (emailrequest.searchKey == "Visitors Only" && emailrequest.serviceType == "SMS")
        //        {
        //            memberList = (from s in db.Member
        //                          where (s.Gender != "Children") & (s.Join == "No")
        //                          select s).ToList();
        //        }
        //        else if (emailrequest.searchKey == "Members Only" && emailrequest.serviceType == "SMS")
        //        {
        //            memberList = (from s in db.Member
        //                          where (s.Gender != "Children") & (s.Join == "Yes")
        //                          select s).ToList();
        //        }
        //        else if (emailrequest.searchKey == "All" && emailrequest.serviceType == "SMS")
        //        {
        //            memberList = (from s in db.Member
        //                          where (s.Gender != "Children")
        //                          select s).ToList();
        //        }
        //        else //send to singleMail
        //        {
        //            //memberList = (from s in db.Member
        //            //              where s.Email == emailrequest.emailAddress & (s.Gender != "Children")
        //            //              select s).ToList();
        //            Mail mail = new Mail();
        //            mail.mobilePhone = emailrequest.mobilephone;
        //            mail.body = emailrequest.body;
        //            mail.subject = emailrequest.subject;
        //            mail.createdDate = DateTime.Now;
        //            mail.serviceType = emailrequest.serviceType;
        //            mail.RequestId = emailrequest.requestId;
        //            mail.searchKey = emailrequest.searchKey;
        //            if (file != null)
        //            {
        //                mail.fileName = file.FileName;
        //            }

        //            db.Mail.Add(mail);
        //            db.SaveChanges();
        //            return "Email Data Successfully Saved.";
        //        }

        //        foreach (var member in memberList)
        //        {
        //            Mail mail = new Mail();
        //            mail.emailAddress = member.Email;
        //            string mobilePhone = "234" + Convert.ToString(member.PhoneNumber);
        //            mail.mobilePhone = mobilePhone;
        //            mail.searchKey = emailrequest.searchKey;
        //            mail.body = emailrequest.body;
        //            mail.subject = emailrequest.subject;
        //            mail.createdDate = DateTime.Now;
        //            mail.serviceType = emailrequest.serviceType;
        //            mail.RequestId = emailrequest.requestId;
        //            if (file != null)
        //            {
        //                mail.fileName = file.FileName;
        //            }

        //            db.Mail.Add(mail);
        //            db.SaveChanges();
        //        }
        //        return "SMS Data Saved Successfully";
        //    }
        //    catch (Exception e)
        //    {
        //        return "InsertMemberDetailsIntoDB For SMS Exception: " + e;
        //    }
        //}

    }
}
