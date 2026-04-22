using EOkul.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EOkul.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=HIKOMAN\\SQLEXPRESS;Database=SchoolDb;Integrated Security=True;TrustServerCertificate=True;");
        }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CourseAssignment>()
                .HasOne(x => x.Teacher)
                .WithMany(x => x.CourseAssignments)
                .HasForeignKey(x => x.TeacherId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CourseAssignment>()
                .HasOne(x => x.Classroom)
                .WithMany(x => x.CourseAssignments)
                .HasForeignKey(x => x.ClassroomId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CourseAssignment>()
                .HasOne(x => x.Course)
                .WithMany(x => x.CourseAssignments)
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Grade>()
                .HasOne(x => x.Student)
                .WithMany(x => x.Grades)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Grade>()
                .HasOne(x => x.Exam)
                .WithMany(x => x.Grades)
                .HasForeignKey(x => x.ExamId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Grade>()
                .HasOne(x => x.CourseAssignment)
                .WithMany(x => x.Grades)
                .HasForeignKey(x => x.CourseAssignmentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
