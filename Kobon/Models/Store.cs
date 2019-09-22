namespace Kobon.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Store")]
    public partial class Store
    {
        public int StoreId { get; set; }

        [StringLength(50)]
        public string StoreName { get; set; }

        [StringLength(50)]
        public string StoreLogo { get; set; }

        [StringLength(50)]
        public string TypeOfStore { get; set; }

        [StringLength(1000)]
        public string StoreAddress { get; set; }

        public int? StorePhoneNo { get; set; }

        [StringLength(50)]
        public string Latitude { get; set; }

        [StringLength(50)]
        public string Longitude { get; set; }

        [StringLength(50)]
        public string Website { get; set; }

        public int? StoreReceiptId { get; set; }

        public int? AccountId { get; set; }
    }
}
