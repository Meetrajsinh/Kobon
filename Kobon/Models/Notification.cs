namespace Kobon.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Notification")]
    public partial class Notification
    {
        public int NotificationId { get; set; }

        [StringLength(50)]
        public string NotificationType { get; set; }

        [StringLength(50)]
        public string NotificationTitle { get; set; }

        [StringLength(1000)]
        public string NotificationDesc { get; set; }

        [StringLength(50)]
        public string NotificationStatus { get; set; }

        public int? AccountId { get; set; }
    }
}
