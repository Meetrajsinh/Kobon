using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Kobon.Models;

namespace Kobon.Controllers
{
    public class StoreController : ApiController
    {
        KobonModel db = new KobonModel();

        [Route("store/allstores")]
        [HttpGet]
        public List<Store> GetAllStores()
        {
            return db.Stores.ToList();
        }

        [Route("store/allstoresbytype")]
        [HttpGet]
        public List<Store> GetAllStoresByType(string StoreType)
        {
            return db.Stores.Where( x => x.TypeOfStore==StoreType).ToList();
        }

        [Route("store/storebyname")]
        [HttpGet]
        public List<Store> GetStoresByName([FromUri]int StoreId,[FromUri]string StoreName)
        {
            List<Store> stores = new List<Store>();
            var store = db.Stores.Find(StoreId);
            stores.Add(store);
            stores.AddRange(db.Stores.Where(x => x.StoreId != StoreId && x.StoreName == StoreName).ToList());
            
            return stores;
        }

        [Route("store/getstorebyid")]
        [HttpGet]
        public Store GetStoreById(int StoreId)
        {
            return db.Stores.Find(StoreId);
        }

        [Route("store/getlocation")]
        [HttpGet]
        public string GetStoreLocation(int StoreId)
        {
            string location = "";
            location = db.Stores.Find(StoreId).Latitude + "," + db.Stores.Find(StoreId).Longitude;
            return location;
        }
    }
}
