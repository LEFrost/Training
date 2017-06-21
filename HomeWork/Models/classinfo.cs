namespace HomeWork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("classinfo")]
    public partial class classinfo
    {
        [Key]
        [StringLength(32)]
        public string class_id { get; set; }

        [StringLength(32)]
        public string teacher_id { get; set; }

        [StringLength(32)]
        public string course_name { get; set; }

        public int? class_start_week { get; set; }

        public int? class_end_week { get; set; }

        [StringLength(32)]
        public string class_time { get; set; }
    }
}
