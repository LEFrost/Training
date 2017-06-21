namespace HomeWork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("studentinfo")]
    public partial class studentinfo
    {
        [Key]
        [StringLength(32)]
        public string stu_id { get; set; }

        [StringLength(32)]
        public string college_name { get; set; }

        [StringLength(32)]
        public string faculty_name { get; set; }

        [StringLength(32)]
        public string stu_name { get; set; }

        [StringLength(32)]
        public string stu_pwd { get; set; }

        [StringLength(32)]
        public string stu_email { get; set; }

        [StringLength(255)]
        public string stu_photo { get; set; }
    }
}
