using GenerarQuery_5.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerarQuery_5.DAL
{
    public class DAO<T> : IDAO<T> where T : class, new()
    {
        public void Alta(T entidad)
        {
            throw new NotImplementedException();
        }

        public void Baja(T entidad)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Listar()
        {
            string query = CrearQueryListar();
            return EjecutarQuery.ExecuteSelectStatement<T>(query);
        }

        private string CrearQueryListar()
        {
            string query = $"select {CrearColumnas()} from {CrearTablas()}";
            return query;
        }

        private object CrearColumnas()
        {
            object resultado = new T();
            return string.Join(",",resultado.GetType().GetProperties()
                .Select(p => p.Name).ToList());
        }

        private object CrearTablas()
        {
            return typeof(T).Name;
        }



        public void Modificar(T entidad)
        {
            throw new NotImplementedException();
        }
    }
}
