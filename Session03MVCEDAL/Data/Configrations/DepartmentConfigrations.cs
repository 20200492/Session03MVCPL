using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Session03MVCEDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session03MVCEDAL.Data.Configrations
{
    internal class DepartmentConfigrations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            //Fluent API for Department Model
            builder.Property(D => D.Id).UseIdentityColumn(10, 10);
            builder.Property(D => D.Code).IsRequired().HasMaxLength(50);
            builder.Property(D => D.Name).IsRequired().HasMaxLength(50);

            builder.HasMany(D => D.Employees)
                   .WithOne(E =>  E.Department)
                   .HasForeignKey(E => E.DepartmetId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
