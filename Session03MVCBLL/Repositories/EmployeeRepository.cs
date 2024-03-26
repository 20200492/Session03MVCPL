using Microsoft.EntityFrameworkCore;
using Session03MVCBLL.Interfaces;
using Session03MVCEDAL.Data;
using Session03MVCEDAL.Data.Migrations;
using Session03MVCEDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session03MVCBLL.Repositories
{
    public class EmployeeRepository : GenaricRepository<Employee>, IEmployeeRepositories
    {
        public EmployeeRepository(DbContextApplications dbcontext) : base(dbcontext) // Ask CLR to Create Object From DbContextApplications
        {

        }
        public IQueryable<Employee> GetByAddress(string address)
        {
            return _dbcontext.Employees.Where(E => E.Address.ToLower() == address.ToLower());
        }

    }
}
