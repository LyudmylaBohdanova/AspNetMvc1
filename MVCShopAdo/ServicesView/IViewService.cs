using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCShopAdo.ServicesView
{
    public interface IViewService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T CreateOrUpdate(T data);
        T Remove(T data);
        void Save();
    }
}
