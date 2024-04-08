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
    public class GenaricRepository<T> : IGenaricRepositories<T> where T : ModelBase
    {
        private protected readonly DbContextApplications _dbcontext; // Null  

        /// if we don't use Dependency Injection
        ///public EmployeeRepository()
        ///{
        ///    _dbcontext = new DbContextApplications(new Microsoft.EntityFrameworkCore.DbContextOptions<DbContextApplications>);
        ///}

        public GenaricRepository(DbContextApplications dbcontext) // Ask CLR for Creating Object from DbContextApplications
        {
            _dbcontext = dbcontext;
        }
        public int Add(T entity)
        {
            //_dbcontext.Set<T>().Add(entity);
            _dbcontext.Add(entity); // EF Core New Feature 
            return _dbcontext.SaveChanges();
        }
        public int Delete(T entity)
        {
            //_dbcontext.Set<T>().Remove(entity);
            _dbcontext.Remove(entity); // EF Core New Feature
            return _dbcontext.SaveChanges();
        }
        public int Update(T entity)
        {
            //_dbcontext.Set<T>().Add(entity);
            _dbcontext.Update(entity); // EF Core New Feature
            return _dbcontext.SaveChanges();
        }
        public IEnumerable<T> GetAll()
           => _dbcontext.Set<T>().AsNoTracking().ToList();
        public T GetById(int id)
        {
            //return _dbcontext.Employees.Find(id);
            return _dbcontext.Find<T>(id); //EF Core New Feature

            ///var Employee = _dbcontext.Employees.Local.Where(D => D.Id == id).FirstOrDefault();
            ///if(Employee is null)
            ///   Employee = _dbcontext.Employees.Where(D => D.Id == id).FirstOrDefault();
        }
    }
}
