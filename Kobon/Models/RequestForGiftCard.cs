namespace Kobon.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RequestForGiftCard")]
    public partial class RequestForGiftCard
    {
        [Key]
        public int RequestId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RequestDate { get; set; }

        [StringLength(50)]
        public string DeliverEmail { get; set; }

        [StringLength(20)]
        public string RequestStatus { get; set; }

        public int? GiftCardId { get; set; }

        public int? AccountId { get; set; }
    }
}
