namespace Kobon.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Wallet")]
    public partial class Wallet
    {
        public int WalletId { get; set; }

        [StringLength(50)]
        public string Amount { get; set; }

        public int? AccountId { get; set; }
    }
}
