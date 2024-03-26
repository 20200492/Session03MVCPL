using Microsoft.EntityFrameworkCore;
using Session03MVCBLL.Interfaces;
using Session03MVCEDAL.Data;
using Session03MVCEDAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session03MVCBLL.Repositories
{
    public class DepartmentRepository:GenaricRepository<Department>,IDepartmentRepositories
    {
        public DepartmentRepository(DbContextApplications dbcontext) :base(dbcontext) // Ask CLR to Create Object From DbContextApplications
        {
            
        }

    }
}
