using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniversityProject.Entities.Entities;

namespace UniversityProject.DataAccess.DataAccept
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public DbSet<Test> Faculties { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestSession> TestSessions { get; set; }
        public DbSet<UserTestSession> UserTestSessions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<ResultNote> ResultNotes { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}