using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Data.SqlClient;
using System.Web.Http;
using System.Data;
using Kobon.Models;

namespace Kobon.Controllers
{
    public class KobonController : ApiController

    {
        KobonModel db = new KobonModel();

        [Route("kobon/gettoken")]
        [HttpGet]
        public String GetToken(String token)
        {
            string userId = "Error";
            if(db.Accounts.Where(x => x.Token == token).FirstOrDefault()!=null)
                userId = db.Accounts.Where(x => x.Token == token).FirstOrDefault().AccountId.ToString();
            return userId;
            
        }
    }
}
