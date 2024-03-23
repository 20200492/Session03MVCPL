using Session03MVCEDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session03MVCBLL.Interfaces
{
    internal interface IEmployeeRepositories
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        int Add(Employee entity);
        int Update(Employee entity);
        int Delete(Employee entity);
    }
}
