using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Kobon.Models;

namespace Kobon.Controllers
{
    public class WalletTransactionController : ApiController
    {
        KobonModel db = new KobonModel();

        [Route("wallet/getwalletsummary")]
        [HttpGet]
        public List<WalletTransaction> GetWalletSummary(int AccountId)
        {
            List<WalletTransaction> walletTransactions = new List<WalletTransaction>();

            var wallet = db.Wallets.Where(x => x.AccountId == AccountId).FirstOrDefault();

            if(wallet!=null)
                walletTransactions.AddRange(db.WalletTransactions.Where(x => x.WalletId == wallet.WalletId));

            return walletTransactions;
        }
    }
}
