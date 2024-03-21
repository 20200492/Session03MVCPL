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

        public DbContextApplications(DbContextOptions<DbContextApplications> options) :base(options)
        {
            
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server =.; Database = MVCApplicationG02; Trusted_Connection = True; MultipleActiveResultSets = False"); 
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration<Department>(new DepartmentConfigrations());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
