using Session03MVCEDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session03MVCBLL.Interfaces
{
    internal interface IDepartmentRepositories
    {
        IEnumerable<Department> GetAll();
        Department GetById(int id);
        int Add(Department entity);
        int Update(Department entity);
        int Delete(Department entity);

    }
}
