using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BEntidad.BModels;

namespace BLogica.BL
{
    public class Usuario
    {

        public IEnumerable<Tmusua> ListarUsua()
        {
            using (NorthwindContext _BD = new NorthwindContext())
            {
                List<Tmusua> _ListadoUsuarios = (from t1 in _BD.Tmusua
                                                  join t2 in _BD.Tmgrup_usua 
                                                  on t1.CoGrup equals t2.Co_grup
                                                  select new Tmusua
                                                  { 
                                                  CoUsua = t1.CoUsua,
                                                  NoUsua = t1.NoUsua,
                                                  CoGrup = t1.CoGrup,
                                                  NoGrup = t2.No_grup,
                                                  }).ToList();
                return _ListadoUsuarios;
            }
        }

        public IEnumerable<Tmgrup_usua> ListarTipoUsuario()
        {
            using (NorthwindContext _BD = new NorthwindContext())
            {
                List<Tmgrup_usua> _ListarTipo = (from t1 in _BD.Tmgrup_usua
                                                 select new Tmgrup_usua
                                                 {
                                                     Co_grup = t1.Co_grup,
                                                     No_grup = t1.No_grup
                                                 }).ToList();
                return _ListarTipo;
            }
        }

        public IEnumerable<Tmusua> BuscarUsuario(string co_grupo)
        {
            using (NorthwindContext _BD = new NorthwindContext())
            {
                List<Tmusua> _ListadoUsuarios = (from t1 in _BD.Tmusua
                                                 join t2 in _BD.Tmgrup_usua
                                                 on t1.CoGrup equals t2.Co_grup
                                                 where t1.CoGrup == co_grupo
                                                 select new Tmusua
                                                 {
                                                     CoUsua = t1.CoUsua,
                                                     NoUsua = t1.NoUsua,
                                                     CoGrup = t1.CoGrup,
                                                     NoGrup = t2.No_grup,
                                                 }).ToList();
                return _ListadoUsuarios;
            }
        }

    }
}
