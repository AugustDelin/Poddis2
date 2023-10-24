using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataLayer.Repositories
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        void Create(T item);
        void Update(T item, string nyttNamn);
        void Delete(T item);
        void Add(T item);
    }
}