namespace HomeWork.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StuAttendance : DbContext
    {
        public StuAttendance()
            : base("name=StuAttendance")
        {
        }

        public virtual DbSet<admininfo> admininfo { get; set; }
        public virtual DbSet<attendanceinfo> attendanceinfo { get; set; }
        public virtual DbSet<classinfo> classinfo { get; set; }
        public virtual DbSet<collegeinfo> collegeinfo { get; set; }
        public virtual DbSet<facultyinfo> facultyinfo { get; set; }
        public virtual DbSet<selectcourse> selectcourse { get; set; }
        public virtual DbSet<studentinfo> studentinfo { get; set; }
        public virtual DbSet<teacherinfo> teacherinfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<admininfo>()
                .Property(e => e.admin_id)
                .IsUnicode(false);

            modelBuilder.Entity<admininfo>()
                .Property(e => e.admin_name)
                .IsUnicode(false);

            modelBuilder.Entity<admininfo>()
                .Property(e => e.admin_pwd)
                .IsUnicode(false);

            modelBuilder.Entity<admininfo>()
                .Property(e => e.admin_email)
                .IsUnicode(false);

            modelBuilder.Entity<attendanceinfo>()
                .Property(e => e.att_id)
                .IsUnicode(false);

            modelBuilder.Entity<attendanceinfo>()
                .Property(e => e.selectcourse_id)
                .IsUnicode(false);

            modelBuilder.Entity<attendanceinfo>()
                .Property(e => e.recordtime)
                .IsUnicode(false);

            modelBuilder.Entity<classinfo>()
                .Property(e => e.class_id)
                .IsUnicode(false);

            modelBuilder.Entity<classinfo>()
                .Property(e => e.teacher_id)
                .IsUnicode(false);

            modelBuilder.Entity<classinfo>()
                .Property(e => e.course_name)
                .IsUnicode(false);

            modelBuilder.Entity<classinfo>()
                .Property(e => e.class_time)
                .IsUnicode(false);

            modelBuilder.Entity<collegeinfo>()
                .Property(e => e.college_name)
                .IsUnicode(false);

            modelBuilder.Entity<collegeinfo>()
                .Property(e => e.college_addr)
                .IsUnicode(false);

            modelBuilder.Entity<collegeinfo>()
                .Property(e => e.college_contact)
                .IsUnicode(false);

            modelBuilder.Entity<collegeinfo>()
                .Property(e => e.college_tel)
                .IsUnicode(false);

            modelBuilder.Entity<facultyinfo>()
                .Property(e => e.faculty_name)
                .IsUnicode(false);

            modelBuilder.Entity<facultyinfo>()
                .Property(e => e.faculty_addr)
                .IsUnicode(false);

            modelBuilder.Entity<facultyinfo>()
                .Property(e => e.faculty_contact)
                .IsUnicode(false);

            modelBuilder.Entity<facultyinfo>()
                .Property(e => e.faculty_tel)
                .IsUnicode(false);

            modelBuilder.Entity<selectcourse>()
                .Property(e => e.selectcourse_id)
                .IsUnicode(false);

            modelBuilder.Entity<selectcourse>()
                .Property(e => e.class_id)
                .IsUnicode(false);

            modelBuilder.Entity<selectcourse>()
                .Property(e => e.stu_id)
                .IsUnicode(false);

            modelBuilder.Entity<studentinfo>()
                .Property(e => e.stu_id)
                .IsUnicode(false);

            modelBuilder.Entity<studentinfo>()
                .Property(e => e.college_name)
                .IsUnicode(false);

            modelBuilder.Entity<studentinfo>()
                .Property(e => e.faculty_name)
                .IsUnicode(false);

            modelBuilder.Entity<studentinfo>()
                .Property(e => e.stu_name)
                .IsUnicode(false);

            modelBuilder.Entity<studentinfo>()
                .Property(e => e.stu_pwd)
                .IsUnicode(false);

            modelBuilder.Entity<studentinfo>()
                .Property(e => e.stu_email)
                .IsUnicode(false);

            modelBuilder.Entity<studentinfo>()
                .Property(e => e.stu_photo)
                .IsUnicode(false);

            modelBuilder.Entity<teacherinfo>()
                .Property(e => e.teacher_id)
                .IsUnicode(false);

            modelBuilder.Entity<teacherinfo>()
                .Property(e => e.faculty_name)
                .IsUnicode(false);

            modelBuilder.Entity<teacherinfo>()
                .Property(e => e.college_name)
                .IsUnicode(false);

            modelBuilder.Entity<teacherinfo>()
                .Property(e => e.teacher_name)
                .IsUnicode(false);

            modelBuilder.Entity<teacherinfo>()
                .Property(e => e.teacher_pwd)
                .IsUnicode(false);

            modelBuilder.Entity<teacherinfo>()
                .Property(e => e.teacher_email)
                .IsUnicode(false);

            modelBuilder.Entity<teacherinfo>()
                .Property(e => e.teacher_photo)
                .IsUnicode(false);
        }
    }
}
