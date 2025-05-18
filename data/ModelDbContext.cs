using Microsoft.EntityFrameworkCore;
using data.Model;

namespace data
{
    public class ModelDbContext : DbContext
    {
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Availability> Availabilities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite("Data Source=tutorat.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Availability>()
                .HasOne(a => a.Student)
                .WithMany(s => s.Availabilities)
                .HasForeignKey(a => a.StudentId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Availability>()
                .HasOne(a => a.Tutor)
                .WithMany(t => t.Availabilities)
                .HasForeignKey(a => a.TutorId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Request>()
                .HasOne(r => r.Student)
                .WithMany(s => s.Requests)
                .HasForeignKey(r => r.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Meeting>()
                .HasOne(m => m.Student)
                .WithMany(s => s.Meetings)
                .HasForeignKey(m => m.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Meeting>()
                .HasOne(m => m.Tutor)
                .WithMany(t => t.Meetings)
                .HasForeignKey(m => m.TutorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Tutor)
                .WithOne(t => t.Student)
                .HasForeignKey<Student>(s => s.TutorId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
