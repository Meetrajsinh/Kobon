using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Kobon.Models;

namespace Kobon.Controllers
{
    public class GiftCardController : ApiController
    {
        KobonModel db = new KobonModel();

        [Route("giftcard/getallgiftcards")]
        [HttpGet]
        public List<GiftCard> GetAllGiftCards()
        {
            return db.GiftCards.ToList();
        }

        [Route("giftcard/getgiftcard")]
        [HttpGet]
        public GiftCard GetGiftCard(int GiftCardId)
        {
            return db.GiftCards.Find(GiftCardId);
        }

        [Route("giftcard/requestgiftcard")]
        [HttpGet]
        public bool RequestGiftCard(int GiftCardId,int AccountId)
        {
            var giftcard = db.GiftCards.Find(GiftCardId);
            if (giftcard != null)
            {
                int cardprice = (int)giftcard.CardPrice;
                int walletAmount = Convert.ToInt32(Double.Parse(db.Wallets.Where(x => x.AccountId == AccountId).FirstOrDefault().Amount));
                if(cardprice <= walletAmount)
                {
                    return true;
                }
            }
            return false;
        }

        [Route("giftcard/submitrequestgiftcard")]
        [HttpGet]
        public bool SubmitRequestGiftCard(int GiftCardId, int AccountId,string deliveremail)
        {
            var giftcard = db.GiftCards.Find(GiftCardId);
            if (giftcard != null)
            {
                RequestForGiftCard card = new RequestForGiftCard();
                card.AccountId = AccountId;
                card.DeliverEmail = deliveremail;
                card.RequestDate = DateTime.Now.Date;
                card.RequestStatus = "Processing";
                card.GiftCardId = GiftCardId;
                db.RequestForGiftCards.Add(card);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
