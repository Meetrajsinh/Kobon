using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Kobon.Models;

namespace Kobon.Controllers
{
    public class ClaimedController : ApiController
    {
        KobonModel db = new KobonModel();

        [Route("claimed/getreceiptfields")]
        [HttpGet]
        public List<string> GetReceiptFields(string StoreType)
        {
            List<string> ReceiptFields = new List<string>();
            string[] fields =  db.StoreReceiptDetails.Where(x => x.TypeOfStore == StoreType).FirstOrDefault().Fields.Split(',');
            foreach(string field in fields)
            {
                ReceiptFields.Add(field);   
            }
            return ReceiptFields;
        }



        [Route("claimed/uploadreceipt")]
        [HttpPost]
        public bool UploadReceipt([FromUri]int ClaimOfferId,[FromBody]Receipt receipt)
        {
            ClaimedOffer co = new ClaimedOffer();
            Receipt r = new Receipt();
            r.ClaimOfferId = ClaimOfferId;

            r.ReceiptFields = receipt.ReceiptFields;
            r.ReceiptInfo = receipt.ReceiptInfo;
            r.ReceiptStatus = "Processing";
            r.StoreId = db.Stores.Find(db.Offers.Find(db.ClaimOffers.Find(ClaimOfferId).OfferId)).StoreId;

            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    string extention = System.IO.Path.GetExtension(postedFile.FileName);
                    string filename = DateTime.Now.ToString("yyyyMMddHHmmss").ToString() + ClaimOfferId.ToString() + extention ;
                    var filePath = HttpContext.Current.Server.MapPath("~/" + filename);
                    postedFile.SaveAs(filePath);
                    r.FilePath = filename;
                }
                db.Receipts.Add(r);
                db.SaveChanges();
                co.ReceiptId = r.ReceiptId;
                co.ClaimedDate = DateTime.Now.Date;
                co.ClaimedTime = DateTime.Now.TimeOfDay;
                co.ClaimOfferId = ClaimOfferId;
                db.ClaimedOffers.Add(co);
                db.SaveChanges();
                db.ClaimOffers.Find(ClaimOfferId).ClaimingStatus = "Processing";
                db.SaveChanges();
            }
                return false;
        }

       
    }
}
