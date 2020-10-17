using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerarQuery_5.DAL
{
    public interface IDAO<T>
    {
        void Alta(T entidad);
        void Baja(T entidad);
        void Modificar(T entidad);
        IEnumerable<T> Listar();
    }
}
