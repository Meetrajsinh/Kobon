using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Net.Http;
using System.Web.Http;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.ComponentModel;
using System.Web;
using Kobon.Models;

namespace Kobon.Controllers
{

    public class AccountController : ApiController
    {
        KobonModel db = new KobonModel();

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        static bool VerifyMd5Hash(MD5 md5Hash, string hashOfInput, string hash)
        {


            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        [Route("account/login")]
        [HttpPost]
        public String Login(Account ac)
        {
            MD5 md5Hash = MD5.Create();
            string hash = GetMd5Hash(md5Hash, ac.Password);

            var user = db.Accounts.Where(x => x.Username == ac.Username).FirstOrDefault();

            if (ac.Username == null)
            {
                user = db.Accounts.Where(x => x.EmailId == ac.EmailId).FirstOrDefault();
            }
            if (user != null && VerifyMd5Hash(md5Hash, hash, user.Password))
            {
                return user.Token;
            }
            return "Error";
        }

        [Route("account/getusername")]
        [HttpGet]
        public String GetUsername(int AccountId)
        {
            return db.Accounts.Find(AccountId).Username;
        }




        [Route("account/register")]
        [HttpPost]
        public List<string> Register(Account account)
        {
           
            int flag = 0;
            MD5 md5Hash = MD5.Create();
            List<string> results = new List<string>();
            var user = db.Accounts.Where(x => x.Username == account.Username).FirstOrDefault();
            
          
            
            if (user != null)
            {
                flag = 1;
                results.Add("Username Exists");
            }
            user = db.Accounts.Where(x => x.EmailId == account.EmailId).FirstOrDefault();
            if (user != null){
                flag = 1;
                results.Add("Email Exists");
            }
            if (flag == 0)
            {
                Account acc = new Account();
                acc.FirstName = account.FirstName;
                acc.LastName = account.LastName;
                acc.Username = account.Username;
                acc.EmailId = account.EmailId;

                acc.Password = GetMd5Hash(md5Hash, account.Password);

                acc.Token = GetMd5Hash(md5Hash, account.FirstName.Substring(0, 1) + account.LastName.Substring(0, 1) + account.EmailId.Substring(3, 2) + account.Username.Substring(0, 3));

                Random random = new Random();

                acc.ReferralCode = account.Username.Substring(0, 4) + random.Next(1000,2000).ToString();
                acc.PhoneNo = account.PhoneNo;
                
                if(account.HaveReferralCode!=null)
                    if(db.Accounts.Where(x=>x.HaveReferralCode == account.HaveReferralCode).FirstOrDefault()!=null)
                        acc.HaveReferralCode = account.HaveReferralCode;
                acc.UserType = "User";
                db.Accounts.Add(acc);
                db.SaveChanges();
                

                System.Web.HttpContext.Current.Application[account.EmailId] = 123456/*random.Next(100000, 900000)*/;
                System.Web.HttpContext.Current.Application[account.EmailId+"-time"] = DateTime.Now.AddMinutes(3).TimeOfDay.ToString(); 
               

                results.Add("Success");
            }
           
            return results;
        }
        
        [Route("account/forgotpassword")]
        [HttpGet]
        public bool ForgotPassword(string EmailId)
        {
            if (db.Accounts.Where(x => x.EmailId == EmailId).FirstOrDefault() != null)
            {
                Random random = new Random();
                System.Web.HttpContext.Current.Application[EmailId] = 123456; /*random.Next(100000, 900000); */
                System.Web.HttpContext.Current.Application[EmailId + "-time"] = DateTime.Now.AddMinutes(3).TimeOfDay.ToString();
                return true;
            }
            return false;
        }

        [Route("account/resetpassword")]
        [HttpPost]
        public bool ResetPassword([FromUri]string EmailId,[FromBody]string NewPassword)
        {
            var account = db.Accounts.Where(x => x.EmailId == EmailId).FirstOrDefault();

            if (account != null)
            {
                MD5 md5Hash = MD5.Create();
                account.Password = GetMd5Hash(md5Hash, NewPassword);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [Route("account/updateprofile")]
        [HttpPut]
        public bool UpdateProfile([FromUri]int AccountId,[FromBody]Account account)
        {
            var user = db.Accounts.Find(AccountId);
            if (user != null)
            {
                user = account;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [Route("account/resendcode")]
        [HttpGet]
        public bool ResendCode(string EmailId)
        {
            System.Web.HttpContext.Current.Application[EmailId] = 123456;
            System.Web.HttpContext.Current.Application[EmailId + "-time"] = DateTime.Now.AddMinutes(3).TimeOfDay.ToString();
            return true;
        }
        
        [Route("account/verifyemail")]
        [HttpPost]
        public bool VerifyEmail([FromBody]string EmailId,[FromUri]string VerifyCode)
        {
            if (System.Web.HttpContext.Current.Application[EmailId] != null) {
                string code = System.Web.HttpContext.Current.Application[EmailId].ToString();
                var min = Convert.ToInt32(DateTime.Now.TimeOfDay.ToString().Split(':')[1]);
                var expire_min = Convert.ToInt32(System.Web.HttpContext.Current.Application[EmailId+"-time"].ToString().Split(':')[1]);
                if (min <= expire_min && VerifyCode == code)
                {
                    System.Web.HttpContext.Current.Application[EmailId] = null;
                    System.Web.HttpContext.Current.Application[EmailId + "-time"] = null;
                    return true;
                }
            }
            return false;
        }
    }
}
