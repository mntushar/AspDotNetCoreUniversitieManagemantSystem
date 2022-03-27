using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DbContexts
{
    public class UniversityDbContext : DbContext
    {
        public DbSet<DepartmentModel> Department { get; set; }
        public DbSet<StudentModel> Student { get; set; }

        public UniversityDbContext()
        {
        }

        public UniversityDbContext(DbContextOptions<UniversityDbContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string ConnectionString = "Server=MNTUSHAR;Database=UniversitieManagemantSystem;Trusted_Connection=True;MultipleActiveResultSets=true;";
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(ConnectionString);
        }
    }
}
