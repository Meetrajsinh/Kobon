namespace Kobon.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClaimedOffer")]
    public partial class ClaimedOffer
    {
        [Key]
        public int ClaimedId { get; set; }

        public TimeSpan? ClaimedTime { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ClaimedDate { get; set; }

        public int? ReceiptId { get; set; }

        public int? ClaimOfferId { get; set; }
    }
}
