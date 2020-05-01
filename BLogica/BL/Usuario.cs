using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BEntidad.BModels;
using System.Security.Cryptography;
using System.Transactions;

namespace BLogica.BL
{
    public class Usuario
    {

        public IEnumerable<_Tmusua> ListarUsua()
        {
            using (NorthwindContext _BD = new NorthwindContext())
            {
                List<_Tmusua> _ListadoUsuarios = (from t1 in _BD.Tmusua
                                                  join t2 in _BD.Tmgrup_usua 
                                                  on t1.CoGrup equals t2.Co_grup
                                                  select new _Tmusua
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

        public IEnumerable<_Tmusua> BuscarUsuarioXGrupo(string co_grupo)
        {
            using (NorthwindContext _BD = new NorthwindContext())
            {
                List<_Tmusua> _ListadoUsuarios = (from t1 in _BD.Tmusua
                                                 join t2 in _BD.Tmgrup_usua
                                                 on t1.CoGrup equals t2.Co_grup
                                                 where t1.CoGrup == co_grupo
                                                 select new _Tmusua
                                                 {
                                                     CoUsua = t1.CoUsua,
                                                     NoUsua = t1.NoUsua,
                                                     CoGrup = t1.CoGrup,
                                                     NoGrup = t2.No_grup,
                                                 }).ToList();
                return _ListadoUsuarios;
            }
        }

        public Tmusua BuscarUsuarioPorId (string idUsuario)
        {
            using (NorthwindContext _BD = new NorthwindContext())
            {
                Tmusua UsuarioId = (from t1 in _BD.Tmusua
                                    where t1.CoUsua == idUsuario
                                    select new Tmusua { 
                                    CoUsua = t1.CoUsua,
                                    NoUsua = t1.NoUsua,
                                    NoClav = t1.NoClav,
                                    CoGrup = t1.CoGrup,
                                    DeDireMail = t1.DeDireMail,
                                    }).First();

                return UsuarioId;
            }
        }

        public int registrarUsuario (Tmusua m)
        {
            int sINSERT = 0;

            using (NorthwindContext _BD = new NorthwindContext())
            {
                try
                {
                    using (var transaccion = new TransactionScope())
                    {

                        Tmusua sUsuario = _BD.Tmusua.Where(p => p.CoUsua == m.CoUsua).First();

                        if (sUsuario.CoUsua != m.CoUsua)
                        {
                            m.CoUsuaCrea = "DBA01";
                            m.CoUsuaModi = "DBA01";
                            m.StActi = "ACT";
                            //Para cifrar contraseña
                            SHA256Managed sha = new SHA256Managed();
                            //byte[] dataNoCifrada = Encoding.Default.GetBytes(m.NoClav);
                            //byte[] dataCifafrada = sha.ComputeHash(dataNoCifrada);
                            //string claveCifrada = BitConverter.ToString(dataCifafrada).Replace("-", "");
                            //m.NoClav = claveCifrada;
                            _BD.Add(m);
                            _BD.SaveChanges();
                            transaccion.Complete();

                            sINSERT = 1;
                        }
                        else
                        {
                            //Tmusua sUsuario = _BD.Tmusua.Where(p => p.CoUsua == m.CoUsua).First();
                            sUsuario.CoUsua = m.CoUsua;
                            sUsuario.NoUsua = m.NoUsua;
                            //sUsuario.NoClav = m.NoClav;
                            sUsuario.CoGrup = m.CoGrup;
                            sUsuario.CoUsuaModi = "DBA01";
                            sUsuario.DeDireMail = m.DeDireMail;
                            _BD.SaveChanges();
                            transaccion.Complete();

                            sINSERT = 1;
                        }
                    } 
                }
                catch (Exception)
                {

                    sINSERT = 0;
                }

                return sINSERT;
            }
        }

        public int eliminarUsuario(string idUsuario)
        {
            int sDELETE = 0;

            using (NorthwindContext _BD = new NorthwindContext())
            {
                try
                {
                    Tmusua sUsuario = _BD.Tmusua.Where(p => p.CoUsua == idUsuario).First();
                    sUsuario.CoUsua = idUsuario;
                    _BD.Tmusua.Remove(sUsuario);
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

        public int validarCodUsuario (string codUsuario)
        {
            int sVALIDA = 0;

            using (NorthwindContext _BD = new NorthwindContext())
            {
                try
                {
                    if (codUsuario == "")
                    {
                        sVALIDA = _BD.Tmusua.Where(p => p.CoUsua.ToLower() == codUsuario.ToLower()).Count();
                    }
                    else
                    {
                        sVALIDA = _BD.Tmusua.Where(p => p.CoUsua.ToLower() == codUsuario.ToLower() && p.CoUsua != codUsuario).Count();
                    }
                }
                catch (Exception)
                {
                    sVALIDA = 0;
                }

                return sVALIDA;
            }
        }

    }
}
