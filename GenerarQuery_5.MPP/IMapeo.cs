using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerarQuery_5.MPP
{
    public interface IMapeo
    {
        T Mapear<T>(DataRow dataRow) where T : class, new();
    }
}
