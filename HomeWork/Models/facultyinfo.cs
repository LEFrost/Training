namespace HomeWork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("facultyinfo")]
    public partial class facultyinfo
    {
        [Key]
        [StringLength(32)]
        public string faculty_name { get; set; }

        [StringLength(32)]
        public string faculty_addr { get; set; }

        [StringLength(32)]
        public string faculty_contact { get; set; }

        [StringLength(18)]
        public string faculty_tel { get; set; }
    }
}
