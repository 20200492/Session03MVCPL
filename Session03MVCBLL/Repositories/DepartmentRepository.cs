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
    public class DepartmentRepository : IDepartmentRepositories
    {
        private readonly DbContextApplications _dbcontext;
        
        /// if we don't use Dependency Injection
        ///public DepartmentRepository()
        ///{
        ///    _dbcontext = new DbContextApplications(new Microsoft.EntityFrameworkCore.DbContextOptions<DbContextApplications>);
        ///}

        public DepartmentRepository(DbContextApplications dbcontext) // Ask CLR for Creating Object from DbContextApplications
        {
            _dbcontext = dbcontext;
        }

        public IEnumerable<Department> GetAll()
           => _dbcontext.Departments.AsNoTracking().ToList();
        public Department GetById(int id)
        {
            //return _dbcontext.Departments.Find(id);
            return _dbcontext.Find<Department>(id); //EF Core New Feature

            ///var department = _dbcontext.Departments.Local.Where(D => D.Id == id).FirstOrDefault();
            ///if(department is null)
            ///   department = _dbcontext.Departments.Where(D => D.Id == id).FirstOrDefault();
        }
        public int Add(Department entity)
        {
            _dbcontext.Departments.Add(entity);
            return _dbcontext.SaveChanges();
        }
        public int Delete(Department entity)
        {
            _dbcontext.Departments.Remove(entity);
            return _dbcontext.SaveChanges();
        }
        public int Update(Department entity)
        {
            _dbcontext.Departments.Update(entity);
            return _dbcontext.SaveChanges();
        }
    }
}
