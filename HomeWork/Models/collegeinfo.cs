namespace HomeWork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("collegeinfo")]
    public partial class collegeinfo
    {
        [Key]
        [StringLength(32)]
        public string college_name { get; set; }

        [StringLength(32)]
        public string college_addr { get; set; }

        [StringLength(32)]
        public string college_contact { get; set; }

        [StringLength(32)]
        public string college_tel { get; set; }
    }
}
