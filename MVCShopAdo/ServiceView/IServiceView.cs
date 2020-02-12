using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCShopAdo.ServiceView
{
    public interface IServiceView<T>
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        T CreateOrUpdate(T data);
        T Remove(T data);
        void Save();
    }
}
