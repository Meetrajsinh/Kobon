using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Kobon.Models;

namespace Kobon.Controllers
{
    public class OfferController : ApiController
    {
        KobonModel db = new KobonModel();

        [Route("offer/getoffers")]
        [HttpGet]
        public List<Offer> GetOffers(int StoreId)
        {
            return db.Offers.Where(x=>x.StoreId==StoreId).ToList();
        }

        [Route("offer/getofferbyid")]
        [HttpGet]
        public Offer GetOfferById(int OfferId)
        {
            return db.Offers.Find(OfferId);
        }

        [Route("offer/getbestofferbystore")]
        [HttpGet]
        public Offer GetBestOfferByStore(int StoreId)
        {
            var offers = db.Offers.Where(x => x.StoreId == StoreId);
            double max = 0.0;
            Offer o = null;
            foreach(Offer offer in offers)
            {
                if (Double.Parse(offer.DiscountPrice) > max)
                {
                    max = Double.Parse(offer.DiscountPrice);
                    o = offer;
                }
            }
            
            return o;
        }
    }
}
