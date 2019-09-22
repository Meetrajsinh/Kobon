namespace Kobon.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GiftCard")]
    public partial class GiftCard
    {
        public int GiftCardId { get; set; }

        [StringLength(50)]
        public string CompanyName { get; set; }

        [StringLength(50)]
        public string CompanyLogo { get; set; }

        public int? CardValidity { get; set; }

        public int? CardPrice { get; set; }

        [StringLength(50)]
        public string TermsAndConditions { get; set; }

        [StringLength(2000)]
        public string Instructions { get; set; }
    }
}
