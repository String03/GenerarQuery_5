using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenerarQuery_5.MPP
{
    public class MapeoGenerico : IMapeo
    {
        public T Mapear<T>(DataRow dataRow) where T : class, new()
        {
            object resultado = new T();
            var properties = resultado.GetType().GetProperties();

            foreach (var prop in properties)
            {
                object col = GetRowValues(dataRow, prop);
                prop.SetValue(resultado,col);
            }
            return (T)resultado;
        }

        private object GetRowValues(DataRow dataRow, PropertyInfo prop)
        {
            object resultados = dataRow[prop.Name];
            return resultados;
        }
    }
}
