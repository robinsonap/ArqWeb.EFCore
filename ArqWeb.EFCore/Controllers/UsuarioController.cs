using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BEntidad.BModels;

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
        public IEnumerable<Tmgrup_usua> ListadoTipoUsuario()
        {
            try
            {
                BLogica.BL.Usuario _Proc = new BLogica.BL.Usuario();

                IEnumerable<Tmgrup_usua> listadoTipo = _Proc.ListarTipoUsuario();

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
        public int validarCodUsuario( string codUsuario)
        {
            BLogica.BL.Usuario _Proc = new BLogica.BL.Usuario();
            int sVALIDA = 0;

            sVALIDA = _Proc.validarCodUsuario(codUsuario);

            return sVALIDA;
        }
    }
}