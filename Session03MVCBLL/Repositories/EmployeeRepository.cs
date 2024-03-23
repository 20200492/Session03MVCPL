using Microsoft.EntityFrameworkCore;
using Session03MVCBLL.Interfaces;
using Session03MVCEDAL.Data;
using Session03MVCEDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session03MVCBLL.Repositories
{
    public class EmployeeRepository : IEmployeeRepositories
    {
        private readonly DbContextApplications _dbcontext; // Null

        /// if we don't use Dependency Injection
        ///public EmployeeRepository()
        ///{
        ///    _dbcontext = new DbContextApplications(new Microsoft.EntityFrameworkCore.DbContextOptions<DbContextApplications>);
        ///}

        public EmployeeRepository(DbContextApplications dbcontext) // Ask CLR for Creating Object from DbContextApplications
        {
            _dbcontext = dbcontext;
        }

        public IEnumerable<Employee> GetAll()
           => _dbcontext.Employees.AsNoTracking().ToList();
        public Employee GetById(int id)
        {
            //return _dbcontext.Employees.Find(id);
            return _dbcontext.Find<Employee>(id); //EF Core New Feature

            ///var Employee = _dbcontext.Employees.Local.Where(D => D.Id == id).FirstOrDefault();
            ///if(Employee is null)
            ///   Employee = _dbcontext.Employees.Where(D => D.Id == id).FirstOrDefault();
        }
        public int Add(Employee entity)
        {
            _dbcontext.Employees.Add(entity);
            return _dbcontext.SaveChanges();
        }
        public int Delete(Employee entity)
        {
            _dbcontext.Employees.Remove(entity);
            return _dbcontext.SaveChanges();
        }
        public int Update(Employee entity)
        {
            _dbcontext.Employees.Update(entity);
            return _dbcontext.SaveChanges();
        }
    }
}
