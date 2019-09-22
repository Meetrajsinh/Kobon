namespace Kobon.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NotificationSetting")]
    public partial class NotificationSetting
    {
        [Key]
        public int SettingId { get; set; }

        [StringLength(10)]
        public string RemainderOnClaimOffer { get; set; }

        [StringLength(10)]
        public string OffersMyLocation { get; set; }

        [StringLength(10)]
        public string NewsUpdatesOffer { get; set; }

        [StringLength(10)]
        public string CashbackOffers { get; set; }

        [StringLength(10)]
        public string CashbackReferrals { get; set; }

        [StringLength(10)]
        public string CashbackEarnedByReferrer { get; set; }

        public int? AccountId { get; set; }
    }
}
