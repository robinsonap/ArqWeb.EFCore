using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BEntidad.BModels;

namespace ArqWeb.EFCore.Controllers
{
    public class CategoriaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("api/Categoria/listarCategorias")]
        public IEnumerable<Categories> ListarCategoria()
        {
            BLogica.BL.Categoria _Proc = new BLogica.BL.Categoria();

            IEnumerable<Categories> rSList = _Proc.lsCategoria();

            return rSList;
        }

        [HttpGet]
        [Route("api/Categoria/FiltrarCategoriaPorNombre/{idCategoria}")]
        public IEnumerable<Products> FiltrarCategoriaPorNombre(int idCategoria)
        {
            BLogica.BL.Categoria _Proc = new BLogica.BL.Categoria();

            IEnumerable<Products> ProductoPorCategoria = _Proc.CategoriaPorNombre(idCategoria);

            return ProductoPorCategoria;

        }
    }
}