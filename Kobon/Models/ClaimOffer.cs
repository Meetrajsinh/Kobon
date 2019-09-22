namespace Kobon.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClaimOffer")]
    public partial class ClaimOffer
    {
        public int ClaimOfferId { get; set; }

        [StringLength(50)]
        public string CashBackAmount { get; set; }

        public TimeSpan? StartTimeOfClaiming { get; set; }

        public TimeSpan? EndTimeOfClaiming { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ClaimingDate { get; set; }

        [StringLength(20)]
        public string ClaimingStatus { get; set; }

        public int? OfferId { get; set; }

        public int? AccountId { get; set; }
    }
}
