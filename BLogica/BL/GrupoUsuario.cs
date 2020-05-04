using System;
using System.Collections.Generic;
using System.Text;
using BEntidad.BModels_Northwind;
using BEntidad.BModels;
using System.Linq;
using System.Transactions;

namespace BLogica.BL
{
    public class GrupoUsuario
    {
        public List<TmgrupUsua> listarGrupoUsuario()
        {
            using (NorthwindContext _BD = new NorthwindContext())
            {
                List<TmgrupUsua> lsGrupoUsuario = (from t1 in _BD.TmgrupUsua
                                                   select new TmgrupUsua
                                                   {
                                                       Co_grup = t1.Co_grup,
                                                       No_grup = t1.No_grup
                                                   }).ToList();

                return lsGrupoUsuario;
            }
        }

        public List<Pagina> listarPaginasGrupoUsuario()
        {
            using (NorthwindContext _BD = new NorthwindContext())
            {
                List<Pagina> lsPaginas = (from t1 in _BD.Pagina
                                          select new Pagina
                                          {
                                              IdPagina = t1.IdPagina,
                                              Mensaje = t1.Mensaje
                                          }).ToList();

                return lsPaginas;
            }
        }

        public _TmgrupUsua listarPaginasRecuperar(string coGrupoUsua)
        {
            _TmgrupUsua _m = new _TmgrupUsua();

            using (NorthwindContext _BD = new NorthwindContext())
            {
                List<Pagina> lsPaginas = (from t1 in _BD.TmgrupUsua
                                          join t2 in _BD.PaginaGrupoUsuario
                                          on t1.Co_grup equals t2.CoGrup
                                          join t3 in _BD.Pagina
                                          on t2.IdPagina equals t3.IdPagina
                                          where t2.CoGrup == coGrupoUsua
                                          select new Pagina
                                          {
                                              IdPagina = t3.IdPagina
                                          }).Distinct().ToList();

                TmgrupUsua m = _BD.TmgrupUsua.Where(p => p.Co_grup == coGrupoUsua).First();

                _m.Co_grup = m.Co_grup;
                _m.No_grup = m.No_grup;
                _m.ListaPagina = lsPaginas;

                return _m;

            }
        }

        public int guardarDatosGrupoUsuario(_TmgrupUsua m)
        {
            int sINSERT = 0;

            //3$4$5$6
            using (NorthwindContext _BD = new NorthwindContext())
            {
                // Cuando se realiza varias operaciones en un mismo proceso se utiliza TransactionScope
                using (var transaccion = new TransactionScope())
                {
                    try
                    {
                        int sEXISTE = 0;

                        sEXISTE = _BD.TmgrupUsua.Where(p => p.Co_grup == m.Co_grup).Count();
                        // Para nuevos registros
                        if (sEXISTE == 0)
                        {
                            TmgrupUsua _m = new TmgrupUsua();
                            _m.Co_grup = m.Co_grup;
                            _m.No_grup = m.No_grup;

                            _BD.Add(_m);
                            _BD.SaveChanges();

                            string[] ids = m.valores.Split("$");
                            for (int i = 0; i < ids.Length; i++)
                            {
                                PaginaGrupoUsuario mPaginaUsuario = new PaginaGrupoUsuario();
                                mPaginaUsuario.IdPagina = int.Parse(ids[i]);
                                mPaginaUsuario.CoGrup = m.Co_grup;

                                _BD.PaginaGrupoUsuario.Add(mPaginaUsuario);
                                _BD.SaveChanges();
                            }

                            transaccion.Complete();
                            sINSERT = 1;
                        }
                        // Para editar
                        else
                        {
                            TmgrupUsua sGrupoUsuario = new TmgrupUsua();
                            sGrupoUsuario = _BD.TmgrupUsua.Where(p => p.Co_grup == m.Co_grup).First();
                            sGrupoUsuario.No_grup = m.No_grup;
                            _BD.SaveChanges();

                            //Convertimos los valores recibidos en un array separados por el Split '$'
                            string[] ids = m.valores.Split("$");

                            // Sacamos todas las páginas asociadas
                            List<PaginaGrupoUsuario> lsPGrupoUsuario = _BD.PaginaGrupoUsuario.Where(p => p.CoGrup == m.Co_grup).ToList();
                            foreach (PaginaGrupoUsuario pag in lsPGrupoUsuario)
                            {
                                PaginaGrupoUsuario dPUsua = _BD.PaginaGrupoUsuario.Where(p => p.CoGrup == m.Co_grup).First();
                            }

                            if (ids.Length < lsPGrupoUsuario.Count())
                            {
                                // Si la cantidad es menos es porque se elimina
                                for (int t = 0; t < lsPGrupoUsuario.Count(); t++)
                                {
                                    int sIdPagina = lsPGrupoUsuario[t].IdPagina;

                                    for (int i = 0; i < ids.Length; i++)
                                    {
                                        //cantidad = lsPGrupoUsuario.Where(p => p.IdPagina == int.Parse(ids[i])).Count();
                                        int _sIdPagina = int.Parse(ids[i]);

                                        if (sIdPagina != _sIdPagina)
                                        {
                                            PaginaGrupoUsuario sEliminar = _BD.PaginaGrupoUsuario.Where(p => p.CoGrup == m.Co_grup && p.IdPagina == sIdPagina).First();
                                            sEliminar.IdPaginaGrupoUsuario = sEliminar.IdPaginaGrupoUsuario;
                                            _BD.PaginaGrupoUsuario.Remove(sEliminar);
                                            _BD.SaveChanges();
                                            break;
                                        }
                                    }
                                }
                            }

                            if (ids.Length > lsPGrupoUsuario.Count())
                            {

                                if ( lsPGrupoUsuario.Count() == 0)
                                {
                                    for (int i = 0; i < ids.Length; i++)
                                    {
                                        //cantidad = lsPGrupoUsuario.Where(p => p.IdPagina == int.Parse(ids[i])).Count();
                                        int _sIdPagina = int.Parse(ids[i]);

                                        PaginaGrupoUsuario sGuardarNew = new PaginaGrupoUsuario();
                                        sGuardarNew.CoGrup = m.Co_grup;
                                        sGuardarNew.IdPagina = _sIdPagina;
                                        _BD.PaginaGrupoUsuario.Add(sGuardarNew);
                                        _BD.SaveChanges();
                                    }
                                }
                                else
                                {
                                    // Si la cantidad es mayor es porque se agrega
                                    for (int t = 0; t < lsPGrupoUsuario.Count(); t++)
                                    {
                                        int sIdPagina = lsPGrupoUsuario[t].IdPagina;

                                        for (int i = 0; i < ids.Length; i++)
                                        {
                                            //cantidad = lsPGrupoUsuario.Where(p => p.IdPagina == int.Parse(ids[i])).Count();
                                            int _sIdPagina = int.Parse(ids[i]);

                                            if (sIdPagina != _sIdPagina)
                                            {
                                                PaginaGrupoUsuario sGuardarNew = new PaginaGrupoUsuario();
                                                sGuardarNew.CoGrup = m.Co_grup;
                                                sGuardarNew.IdPagina = _sIdPagina;
                                                _BD.PaginaGrupoUsuario.Add(sGuardarNew);
                                                _BD.SaveChanges();
                                            }
                                        }
                                    }
                                }
                                
                            }

                            transaccion.Complete();
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
        }

        public int eliminarGrupoUsuario(string codGrupoUsuario)
        {
            int sDELETE = 0;

            using (NorthwindContext _BD = new NorthwindContext())
            {
                try
                {
                    TmgrupUsua m = _BD.TmgrupUsua.Where(p => p.Co_grup == codGrupoUsuario).First();
                    m.Co_grup = codGrupoUsuario;
                    _BD.TmgrupUsua.Remove(m);
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
