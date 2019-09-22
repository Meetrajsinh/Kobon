namespace Kobon.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StoreReceiptDetail")]
    public partial class StoreReceiptDetail
    {
        [Key]
        public int StoreReceiptId { get; set; }

        [StringLength(50)]
        public string TypeOfStore { get; set; }

        [StringLength(1000)]
        public string Fields { get; set; }
    }
}
