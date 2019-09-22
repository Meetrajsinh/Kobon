using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Kobon.Models;

namespace Kobon.Controllers
{
    public class ClaimController : ApiController
    {
        KobonModel db = new KobonModel();

        [Route("cliam/cliamingoffer")]
        [HttpGet]
        public string ClaimingOffer(int AccountId,int OfferId)
        {
            
            var offer = db.Offers.Find(OfferId);
            ClaimOffer coffer = new ClaimOffer();
            coffer.OfferId = OfferId;
            coffer.AccountId = AccountId;
            coffer.ClaimingDate = DateTime.Now.Date;
            coffer.StartTimeOfClaiming = DateTime.Now.TimeOfDay;
            coffer.CashBackAmount = ((Double.Parse(offer.OriginalPrice) * Double.Parse(offer.DiscountPrice))/100).ToString();
            coffer.ClaimingStatus = "Running";
            double hours = Convert.ToDouble(offer.UserDuration);
            coffer.EndTimeOfClaiming = DateTime.Now.AddHours(hours).TimeOfDay;
            db.ClaimOffers.Add(coffer);
            db.SaveChanges();
            return coffer.ClaimOfferId.ToString();
        }

        [Route("claim/expireoffer")]
        [HttpGet]
        public bool ExpireOffer(int ClaimOfferId)
        {
            db.ClaimOffers.Find(ClaimOfferId).ClaimingStatus = "Expired";
            return true;
        }
        
        [Route("claim/getclaimoffer")]
        [HttpGet]
        public ClaimOffer GetClaimedOffer(int ClaimOfferId)
        {

            return db.ClaimOffers.Find(ClaimOfferId);
        }

        [Route("claim/offercancel")]
        [HttpGet]
        public bool OfferCancelled(int ClaimOfferId)
        {
            db.ClaimOffers.Find(ClaimOfferId).ClaimingStatus = "Cancelled";
            return true;
        }

        [Route("claim/getallclaimoffers")]
        [HttpGet]
        public List<ClaimOffer> GetAllClaimOffers(int AccountId)
        {
            return db.ClaimOffers.Where(x => x.AccountId == AccountId).ToList();
        }

        [Route("claim/getclaimofferstoreoffer")]
        [HttpGet]
        public Offer GetClaimOfferStoreOffer(int OfferId)
        {
            return db.Offers.Find(OfferId);
        }

        

        [Route("claim/getfilteredclaimoffersbytypes")]
        [HttpGet]
        public List<Store> GetFilteredClaimOffersByTypes(string StoreTypes)
        {
            List<Store> stores = new List<Store>();
            if (StoreTypes.Contains(","))
            {
                string[] StoreType = StoreTypes.Split(',');
               
                foreach (string type in StoreType)
                {
                    stores.AddRange(db.Stores.Where(x => x.TypeOfStore == type));
                }
                
            }
            else
            {
                stores.AddRange(db.Stores.Where(x => x.TypeOfStore == StoreTypes));
            }
            return stores;
        }

        [Route("claim/getfilteredclaimoffersbydates")]
        [HttpGet]
        public List<ClaimOffer> GetFilteredClaimOffersByDates(int month,int year)
        {
            List<ClaimOffer> claimOffers = new List<ClaimOffer>();
            if (month != 0)
            {
                foreach(ClaimOffer co in db.ClaimOffers)
                {
                    string m = (co.ClaimingDate.ToString().Split(' ')[0]).Split('-')[1] ;
                    if (month.ToString().Equals(m)){
                        claimOffers.Add(co);
                    }

                }
            }
            if (year != 0)
            {
                foreach (ClaimOffer co in db.ClaimOffers)
                {
                    string y = (co.ClaimingDate.ToString().Split(' ')[0]).Split('-')[2];
                    if (year.ToString().Equals(y)){
                        claimOffers.Add(co);
                    }

                }
            }
            return claimOffers;
        }
    }
}
