using Microsoft.EntityFrameworkCore;
using RESTfull.Domain.Model;

namespace RESTfull.Infrastructure.Data
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options): base(options) 
        { 
        }

        public DbSet<Student> students { get; set; }
        public DbSet<Class> classes { get; set; }
        public DbSet<Attendance> attendances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Attendance>()
                .HasKey(sc => new { sc.Id_student, sc.Id_class });
            modelBuilder.Entity<Attendance>()
                .HasOne(c => c.Student)
                .WithMany(sc => sc.StudentClass)
                .HasForeignKey(c => c.Student.Id);
            modelBuilder.Entity<Attendance>()
                .HasOne(c => c.Class)
                .WithMany(sc => sc.StudentClass)
                .HasForeignKey(s => s.Class.Id);*/
        }
    }
}