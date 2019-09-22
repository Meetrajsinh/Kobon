namespace Kobon.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Receipt")]
    public partial class Receipt
    {
        public int ReceiptId { get; set; }

        [StringLength(2000)]
        public string ReceiptFields { get; set; }

        [StringLength(1000)]
        public string ReceiptInfo { get; set; }

        [StringLength(50)]
        public string FilePath { get; set; }

        [StringLength(20)]
        public string ReceiptStatus { get; set; }

        public int? ClaimOfferId { get; set; }

        public int? StoreId { get; set; }
    }
}
