namespace Kobon.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WalletTransaction")]
    public partial class WalletTransaction
    {
        [Key]
        public int TransactionId { get; set; }

        [StringLength(50)]
        public string TransactionType { get; set; }

        [StringLength(100)]
        public string TransactionDesc { get; set; }

        [StringLength(50)]
        public string Amount { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TransactionDate { get; set; }

        public TimeSpan? TransactionTime { get; set; }

        public int? WalletId { get; set; }
    }
}
