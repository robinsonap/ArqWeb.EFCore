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
        public IEnumerable<Tmusua> ListarUsuario()
        {
            try
            {
                BLogica.BL.Usuario _Proc = new BLogica.BL.Usuario();

                IEnumerable<Tmusua> ListarUsuario = _Proc.ListarUsua();

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
        public IEnumerable<Tmusua> FiltrarUsuarioPorTipo(string co_grupo = "")
        {
            try
            {
                BLogica.BL.Usuario _Proc = new BLogica.BL.Usuario();

                IEnumerable<Tmusua> listadoTipo = _Proc.BuscarUsuario(co_grupo);

                return listadoTipo;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}