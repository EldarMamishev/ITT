using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniversityProject.Entities.Entities;

namespace UniversityProject.DataAccess.DataAccept
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Cathedra> Cathedras { get; set; }
        public DbSet<Journal> Journals { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Statement> Statements { get; set; }
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }
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