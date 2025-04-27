using data.Model;
using Microsoft.EntityFrameworkCore;

namespace data
{
    public class ModelDbContext : DbContext
    {
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite("Data Source=tutorat.db");

    }
}
