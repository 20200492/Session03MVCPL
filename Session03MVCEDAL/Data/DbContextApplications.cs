using Microsoft.EntityFrameworkCore;
using Session03MVCEDAL.Data.Configrations;
using Session03MVCEDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Session03MVCEDAL.Data
{
    public class DbContextApplications : DbContext
    {
        /// In Case We don't Use Dependancy Injection
        ///public DbContextApplications():base()
        ///{ 
        ///}
        ///protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        ///{
        ///    optionsBuilder.UseSqlServer("Server =.; Database = MVCApplicationG02; Trusted_Connection = True; MultipleActiveResultSets = False"); 
        ///}
       
        // In Case We Use Dependancy Injection:
        // We don't Override OnConfiguring and make It Implementation in Startup Class
        // We don't make Parameterless Constructor but Make Constructor like this :
        public DbContextApplications(DbContextOptions<DbContextApplications> options) :base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration<Department>(new DepartmentConfigrations());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Department> Departments { get; set; }
    }
}
