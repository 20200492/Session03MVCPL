using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session03MVCBLL.Interfaces
{
    public interface IUnitOfWork :IDisposable
    {
        public IEmployeeRepositories EmployeeRepository { get; set; }
        public IDepartmentRepositories DepartmentRepository { get; set; }

        int Complete();

    }
}
