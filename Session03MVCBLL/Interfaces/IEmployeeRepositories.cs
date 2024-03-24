using Session03MVCEDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session03MVCBLL.Interfaces
{
    public interface IEmployeeRepositories : IGenaricRepositories<Employee>
    {
        public IQueryable<Employee> GetByAddress(string address);
    }
}
