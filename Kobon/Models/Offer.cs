namespace Kobon.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Offer")]
    public partial class Offer
    {
        public int OfferId { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        [StringLength(50)]
        public string OriginalPrice { get; set; }

        [StringLength(50)]
        public string DiscountPrice { get; set; }

        [StringLength(2000)]
        public string OfferDescription { get; set; }

        [StringLength(20)]
        public string Duration { get; set; }

        public int? UserDuration { get; set; }

        [StringLength(20)]
        public string PaymentMethod { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpiredDate { get; set; }

        [StringLength(10)]
        public string OfferStatus { get; set; }

        public int? StoreId { get; set; }
    }
}
