using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface GetDataInterface<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Delete(int id);
    }
}
