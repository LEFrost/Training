namespace HomeWork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("selectcourse")]
    public partial class selectcourse
    {
        [Key]
        [StringLength(36)]
        public string selectcourse_id { get; set; }

        [StringLength(32)]
        public string class_id { get; set; }

        [StringLength(32)]
        public string stu_id { get; set; }
    }
}
