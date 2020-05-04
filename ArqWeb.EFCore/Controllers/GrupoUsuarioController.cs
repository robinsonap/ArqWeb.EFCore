using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BEntidad.BModels_Northwind;
using BEntidad.BModels;

namespace ArqWeb.EFCore.Controllers
{
    public class GrupoUsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("api/GrupoUsuario/listarGrupoUsuario")]
        public List<TmgrupUsua> listarGrupoUsuario()
        {
            try
            {
                BLogica.BL.GrupoUsuario _Proc = new BLogica.BL.GrupoUsuario();

                List<TmgrupUsua> lsGrupoUsuario = _Proc.listarGrupoUsuario();

                return lsGrupoUsuario;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("api/GrupoUsuario/listarPaginasGrupoUsuario")]
        public List<Pagina> listarPaginasGrupoUsuario()
        {
            try
            {
                BLogica.BL.GrupoUsuario _Proc = new BLogica.BL.GrupoUsuario();

                List<Pagina> lsPaginas = _Proc.listarPaginasGrupoUsuario();

                return lsPaginas;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("api/GrupoUsuario/listarPaginasRecuperar/{coGrupoUsua}")]
        public _TmgrupUsua listarPaginasRecuperar(string coGrupoUsua)
        {
            try
            {
                BLogica.BL.GrupoUsuario _Proc = new BLogica.BL.GrupoUsuario();

                _TmgrupUsua _m = _Proc.listarPaginasRecuperar(coGrupoUsua);

                return _m;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("api/GrupoUsuario/guardarDatosGrupoUsuario")]
        public int guardarDatosGrupoUsuario([FromBody] _TmgrupUsua m)
        {
            try
            {
                int sINSERT = 0;
                BLogica.BL.GrupoUsuario _Proc = new BLogica.BL.GrupoUsuario();

                sINSERT = _Proc.guardarDatosGrupoUsuario(m);

                return sINSERT;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("api/GrupoUsuario/eliminarGrupoUsuario/{codGrupoUsuario}")]
        public int eliminarGrupoUsuario (string codGrupoUsuario)
        {
            try
            {
                int sDELETE = 0;
                BLogica.BL.GrupoUsuario _Proc = new BLogica.BL.GrupoUsuario();

                sDELETE = _Proc.eliminarGrupoUsuario(codGrupoUsuario);

                return sDELETE;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public int guardarDatos([FromBody] TmgrupUsua m)
        //{

        //}
    }
}