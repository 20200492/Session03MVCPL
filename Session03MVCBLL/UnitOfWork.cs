using Microsoft.EntityFrameworkCore;
using Session03MVCBLL.Interfaces;
using Session03MVCBLL.Repositories;
using Session03MVCEDAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session03MVCBLL
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly DbContextApplications _dbContext;
        public IEmployeeRepositories EmployeeRepository { get ; set; }
        public IDepartmentRepositories DepartmentRepository { get; set; }

        public UnitOfWork(DbContextApplications dbContext)
        {
            _dbContext = dbContext;
            EmployeeRepository = new EmployeeRepository(_dbContext);
            DepartmentRepository = new DepartmentRepository(_dbContext);
            
        }
        public int Complete()
        {
            return _dbContext.SaveChanges();
        }
        public void Dispose()
        {
           _dbContext.Dispose();
        }
    }
}
