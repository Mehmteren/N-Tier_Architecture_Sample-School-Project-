using Microsoft.EntityFrameworkCore;
using school.Entities;
using System;

namespace School.DataAccess
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=mehmetce\\SQLKODLAB; Database=SchoolDb; Integrated Security=True;TrustServerCertificate=True;");
        }

        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Person> Persons { get; set; }

        public DbSet<Teacher>Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentScore> StudentScores { get; set; }
    }

}
