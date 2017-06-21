namespace HomeWork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("admininfo")]
    public partial class admininfo
    {
        [Key]
        [StringLength(32)]
        public string admin_id { get; set; }

        [StringLength(32)]
        public string admin_name { get; set; }

        [StringLength(32)]
        public string admin_pwd { get; set; }

        [StringLength(32)]
        public string admin_email { get; set; }
    }
}
