using Application.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
   public class MemoryStorage<T> : IMemoryStorage<T> where T : BaseModel
    {
        private static List<T> _list = new List<T>();

        public string Create(T item)
        {
                _list.Add(item);

            return item.Id;

        }

        public string Delete(string id)
        {
            var elementToDelete = _list.Where(i=>i.Id == id).FirstOrDefault();

            _list.Remove(elementToDelete);

            return elementToDelete.Id;

        }

        public string Edit(T item)
        {
            var elementToUpdate = _list.Where(i => i.Id == item.Id).FirstOrDefault();

            _list.Remove(elementToUpdate);

            _list.Add(item);

            return item.Id;

        }

        public List<T> GetAll()
        {
            return _list;
        }

        public T GetById(string id)
        {
            var item = _list.Find(i=>i.Id==id);

            return item;
        }

    }
}
