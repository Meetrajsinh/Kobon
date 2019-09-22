namespace Kobon.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        public int AccountId { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string EmailId { get; set; }

        [StringLength(50)]
        public string ReferralCode { get; set; }

        [StringLength(50)]
        public string HaveReferralCode { get; set; }

        public int? PhoneNo { get; set; }

        [StringLength(50)]
        public string Token { get; set; }

        [StringLength(50)]
        public string UserType { get; set; }
    }
}
