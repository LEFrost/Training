namespace HomeWork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("attendanceinfo")]
    public partial class attendanceinfo
    {
        [Key]
        [StringLength(36)]
        public string att_id { get; set; }
        [StringLength(36)]
        public string selectcourse_id { get; set; }
        [StringLength(20)]
        public string recordtime { get; set; }

        public int?recordstatus { get; set; }
    }
}
