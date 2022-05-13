using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMemoryStorage<T>
    {

        string Create(T item);

        string Edit(T item);

        string Delete(string id);

        List<T> GetAll();

        T GetById(string id);


    }
}
