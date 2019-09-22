using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Kobon.Models;

namespace Kobon.Controllers
{
    public class NotificationSettingController : ApiController
    {
        KobonModel db = new KobonModel();

        [Route("notificationsettings/getsettings")]
        [HttpGet]
        public NotificationSetting GetSettings(int AccountId)
        {
            return db.NotificationSettings.Where(x => x.AccountId == AccountId).FirstOrDefault();
        }

        [Route("notificationsettings/updatesettings")]
        [HttpPost]
        public bool UpdateSettings([FromUri]int AccountId,NotificationSetting setting)
        {
            var settings = db.NotificationSettings.Where(x => x.AccountId == AccountId).FirstOrDefault();
            if (settings != null)
            {
                db.NotificationSettings.Remove(settings);
                db.NotificationSettings.Add(setting);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
