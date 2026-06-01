using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Interfaces
{
    public interface FormSubmitInterface<T>{
        void Add(T product);
        public void Update(int id, T updated);
    }
}
