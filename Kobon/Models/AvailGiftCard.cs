namespace Kobon.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AvailGiftCard")]
    public partial class AvailGiftCard
    {
        public int AvailGiftCardId { get; set; }

        [StringLength(50)]
        public string ClaimCode { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpiryDate { get; set; }

        [StringLength(50)]
        public string Value { get; set; }

        [StringLength(50)]
        public string GiftCardStatus { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UsedDate { get; set; }

        public int? WalletId { get; set; }

        public int? RequestId { get; set; }

        public int? AccountId { get; set; }
    }
}
