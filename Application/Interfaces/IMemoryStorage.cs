using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMemoryStorage<T>
    {

        void Create(T item);

        void Edit(T item);

        void Delete(int id);

        List<T> GetAll();

        T GetById(int id);


    }
}
