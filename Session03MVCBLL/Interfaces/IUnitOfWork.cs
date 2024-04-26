using Session03MVCEDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session03MVCBLL.Interfaces
{
    public interface IUnitOfWork :IDisposable
    {
        IGenaricRepositories<T> Repository<T>() where T : ModelBase;
        int Complete();

    }
}
