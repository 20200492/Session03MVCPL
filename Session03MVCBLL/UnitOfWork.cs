using Microsoft.EntityFrameworkCore;
using Session03MVCBLL.Interfaces;
using Session03MVCBLL.Repositories;
using Session03MVCEDAL.Data;
using Session03MVCEDAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session03MVCBLL
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly DbContextApplications _dbContext;
        //private Dictionary<string, IGenaricRepositories<ModelBase>> repositories;
        private Hashtable _repositories;


        public UnitOfWork(DbContextApplications dbContext) // Ask CLR Creating Object from 'DbContext'
        {
            _dbContext = dbContext;
            //EmployeeRepository = new EmployeeRepository(_dbContext);
            //DepartmentRepository = new DepartmentRepository(_dbContext);
        }
        public int Complete()
        {
            return _dbContext.SaveChanges();
        }
        public void Dispose()
        {
           _dbContext.Dispose();
        }

        public IGenaricRepositories<T> Repository<T>() where T : ModelBase
        {
            var Key = typeof(T).Name; // Employee

            if(!_repositories.ContainsKey(Key))
            {
                var repositories = new EmployeeRepository(_dbContext);
                _repositories.Add(Key, repositories);
            }
            else
            {
                var repositories = new GenaricRepository<T>(_dbContext);
                _repositories.Add(Key, repositories);

            }

            return _repositories[Key] as IGenaricRepositories<T>;
        }
    }
}
