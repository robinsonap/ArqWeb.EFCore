using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BEntidad.BModels;
using BEntidad.BModels_Northwind;
//Importamos 
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;

namespace ArqWeb.EFCore.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("api/Usuario/ListarUsuario")]
        public IEnumerable<_Tmusua> ListarUsuario()
        {
            try
            {
                BLogica.BL.Usuario _Proc = new BLogica.BL.Usuario();

                IEnumerable<_Tmusua> ListarUsuario = _Proc.ListarUsua();

                return ListarUsuario;

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("api/Usuario/ListadoTipoUsuario")]
        public IEnumerable<TmgrupUsua> ListadoTipoUsuario()
        {
            try
            {
                BLogica.BL.Usuario _Proc = new BLogica.BL.Usuario();

                IEnumerable<TmgrupUsua> listadoTipo = _Proc.ListarTipoUsuario();

                return listadoTipo;

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("api/Usuario/FiltrarUsuarioPorTipo/{co_grupo?}")]
        public IEnumerable<_Tmusua> FiltrarUsuarioPorTipo(string co_grupo = "")
        {
            try
            {
                BLogica.BL.Usuario _Proc = new BLogica.BL.Usuario();

                IEnumerable<_Tmusua> listadoTipo = _Proc.BuscarUsuarioXGrupo(co_grupo);

                return listadoTipo;

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("api/Usuario/BuscarUsuarioPorId/{idUsuario?}")]
        public Tmusua BuscarUsuarioPorId (string idUsuario)
        {
            try
            {
                BLogica.BL.Usuario _Proc = new BLogica.BL.Usuario();

                Tmusua UsuarioId = _Proc.BuscarUsuarioPorId(idUsuario);

                return UsuarioId;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("api/Usuario/registrarUsuario")]
        public int registrarUsuario ([FromBody] Tmusua m)
        {
            try
            {
                BLogica.BL.Usuario _Proc = new BLogica.BL.Usuario();
                int sINSERT = 0;

                sINSERT = _Proc.registrarUsuario(m);

                return sINSERT;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("api/Usuario/eliminarUsuario/{idUsuario?}")]
        public int eliminarUsuario (string idUsuario = "")
        {
            try
            {
                int sDELETE = 0;
                BLogica.BL.Usuario _Proc = new BLogica.BL.Usuario();

                sDELETE = _Proc.eliminarUsuario(idUsuario);

                return sDELETE;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("api/Usuario/validarCodUsuario/{codUsuario?}")]
        public int validarCodUsuario( string codUsuario = "")
        {
            try
            {
                BLogica.BL.Usuario _Proc = new BLogica.BL.Usuario();
                int sVALIDA = 0;

                sVALIDA = _Proc.validarCodUsuario(codUsuario);

                return sVALIDA;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        [HttpGet]
        [Route("api/Usuario/obtenerVariableSession")]
        public Seguridad obtenerVariableSession()
        {
            try
            {
                Seguridad sSeguridad = new Seguridad();
                string variableSession = HttpContext.Session.GetString("CodUsuario_Session");

                if (variableSession == null)
                {
                    sSeguridad.sValor = "";
                }
                else
                {
                    sSeguridad.sValor = variableSession;
                    //List<Pagina> lsPagina = new List<Pagina>();
                    //string idUsuario =HttpContext.Session.GetString("CodUsuario_Session");
                    //string grupoUsuario = HttpContext.Session.GetString("GrupoUsuario_Session");
                }

                return sSeguridad;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        [HttpPost]
        [Route("api/Usuario/login")]
        public Tmusua login([FromBody] Tmusua m)
        {
            try
            {
                BLogica.BL.Usuario _Proc = new BLogica.BL.Usuario();

                Tmusua sUsuario_res = _Proc.login(m);

                if (sUsuario_res.CoUsua != "" & sUsuario_res.CoGrup != "")
                {
                    HttpContext.Session.SetString("CodUsuario_Session", sUsuario_res.CoUsua.ToString());
                    HttpContext.Session.SetString("GrupoUsuario_Session", sUsuario_res.CoGrup.ToString());
                }
                else
                {
                    sUsuario_res.CoUsua = "";
                    sUsuario_res.NoUsua = "";
                }

                return sUsuario_res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("api/Usuario/cerrarSession")]
        public Seguridad cerrarSession()
        {
            Seguridad sSeguridad = new Seguridad();

            try
            {
                HttpContext.Session.Remove("CodUsuario_Session");
                HttpContext.Session.Remove("GrupoUsuario_Session");

                sSeguridad.sValor = "OK";
            }
            catch (Exception)
            {
                sSeguridad.sValor = "";
                throw;
            }

            return sSeguridad;
        }

        [HttpGet]
        [Route("api/Usuario/listarPaginasPorUsua")]
        public List<Pagina> listarPaginasPorUsua()
        {
            try
            {
                BLogica.BL.Usuario _Proc = new BLogica.BL.Usuario();
                string grupoUsuario = HttpContext.Session.GetString("GrupoUsuario_Session");

                List<Pagina> lsPagina = _Proc.listarPaginas(grupoUsuario);

                return lsPagina;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}