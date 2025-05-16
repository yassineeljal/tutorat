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
                .IsRequired(false);

            modelBuilder.Entity<Availability>()
                .HasOne(a => a.Tutor)
                .WithMany(t => t.Availabilities)
                .HasForeignKey(a => a.TutorId)
                .IsRequired(false);
        }
    }
}
