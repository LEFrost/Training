namespace HomeWork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("teacherinfo")]
    public partial class teacherinfo
    {
        [Key]
        [StringLength(32)]
        public string teacher_id { get; set; }

        [StringLength(32)]
        public string faculty_name { get; set; }

        [StringLength(32)]
        public string college_name { get; set; }

        [StringLength(32)]
        public string teacher_name { get; set; }

        [StringLength(32)]
        public string teacher_pwd { get; set; }

        [StringLength(32)]
        public string teacher_email { get; set; }

        [StringLength(255)]
        public string teacher_photo { get; set; }
    }
}
