using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BEntidad.BModels;
using BEntidad.BModels_Northwind;

namespace ArqWeb.EFCore.Controllers
{
    public class PaginaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("api/Pagina/listadoDePaginasMenu")]
        public IEnumerable<Pagina> listadoDePaginasMenu()
        {
            try
            {
                BLogica.BL.Paginas _Proc = new BLogica.BL.Paginas();

                IEnumerable<Pagina> lsPagina = _Proc.listarPaginas();

                return lsPagina;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("api/Pagina/obtenerPaginaPorId/{idPagina}")]
        public Pagina obtenerPaginaPorId(int idPagina)
        {
            try
            {
                BLogica.BL.Paginas _Proc = new BLogica.BL.Paginas();

                Pagina lsPagina = _Proc.obtenerPaginaPorId(idPagina);

                return lsPagina;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("api/Pagina/registrarPagina")]
        public int registrarPagina([FromBody] Pagina m)
        {
            try
            {
                int sINSERT = 0;
                BLogica.BL.Paginas _Proc = new BLogica.BL.Paginas();

                sINSERT = _Proc.registrarPagina(m);

                return sINSERT;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("api/Pagina/eliminarPagina/{idPagina}")]
        public int eliminarPagina(int idPagina)
        {
            try
            {
                int sDELETE = 0;
                BLogica.BL.Paginas _Proc = new BLogica.BL.Paginas();

                sDELETE = _Proc.eliminarPagina(idPagina);

                return sDELETE;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}