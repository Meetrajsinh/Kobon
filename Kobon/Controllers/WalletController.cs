using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Kobon.Models;

namespace Kobon.Controllers
{
    public class WalletController : ApiController
    {
        KobonModel db = new KobonModel();

        [Route("wallet/getbalance")]
        [HttpGet]
        public Wallet GetBalance(int AccountId)
        {
            return db.Wallets.Where(x => x.AccountId == AccountId).FirstOrDefault();
        }

       
    }
}
