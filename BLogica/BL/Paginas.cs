using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEntidad.BModels;
using BEntidad.BModels_Northwind;

namespace BLogica.BL
{
    public class Paginas
    {
        public IEnumerable<Pagina> listarPaginas()
        {
            using (NorthwindContext _BD = new BEntidad.BModels_Northwind.NorthwindContext())
            {
                IEnumerable<Pagina> lsPaginas = (from t1 in _BD.Pagina
                                                 select new BEntidad.BModels_Northwind.Pagina
                                                 {
                                                     IdPagina = t1.IdPagina,
                                                     Mensaje = t1.Mensaje,
                                                     Accion = t1.Accion
                                                 }).ToList();

                return lsPaginas;
            }
                
        }

        public Pagina obtenerPaginaPorId(int idPagina)
        {
            using (NorthwindContext _BD = new NorthwindContext())
            {
                Pagina lsPaginas = (from t1 in _BD.Pagina
                                                 where t1.IdPagina == idPagina
                                                 select new BEntidad.BModels_Northwind.Pagina
                                                 {
                                                     IdPagina = t1.IdPagina,
                                                     Mensaje = t1.Mensaje,
                                                     Accion = t1.Accion
                                                 }).First();

                return lsPaginas;
            }

        }

        public int registrarPagina (Pagina m)
        {
            int sINSERT = 0;

            using (NorthwindContext _BD = new NorthwindContext())
            {
                try
                {
                    if (m.IdPagina == 0)
                    {
                        _BD.Pagina.Add(m);
                        _BD.SaveChanges();
                        sINSERT = 1;
                    }
                    else
                    {
                        Pagina sUpdate = _BD.Pagina.Where(p => p.IdPagina == m.IdPagina).First();
                        sUpdate.Mensaje = m.Mensaje;
                        sUpdate.Accion = m.Accion;
                        _BD.SaveChanges();
                        sINSERT = 1;
                    }
                }
                catch (Exception)
                {
                    sINSERT = 0;
                }

                return sINSERT;
            }
        }

        public int eliminarPagina(int idPagina)
        {
            int sDELETE = 0;

            using (NorthwindContext _BD = new NorthwindContext())
            {
                try
                {
                    Pagina sEliminarPagina = _BD.Pagina.Where(p => p.IdPagina == idPagina).First();
                    sEliminarPagina.IdPagina = idPagina;
                    _BD.Pagina.Remove(sEliminarPagina);
                    _BD.SaveChanges();

                    sDELETE = 1;
                }
                catch (Exception)
                {
                    sDELETE = 0;
                }

                return sDELETE;
            }
        }
    }
}
