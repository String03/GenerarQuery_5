using GenerarQuery_5.DAL;
using GenerarQuery_5.EE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerarQuery_5.BLL
{
    public class GeneroBLL
    {
        private readonly IDAO<Genero> dAO = new DAO<Genero>();

        public IEnumerable<Genero> ListarGenero()
        {
            return dAO.Listar();
        }
    }
}
