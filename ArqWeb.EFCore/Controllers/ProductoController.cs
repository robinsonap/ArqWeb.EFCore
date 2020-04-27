using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BEntidad.BModels;

namespace ArqWeb.EFCore.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("api/Producto/ListarProductos")]
        public IEnumerable<Products> ListarProductos()
        {
            BLogica.BL.ListProducts _Proc = new BLogica.BL.ListProducts();

            IEnumerable<Products> ResuList = _Proc.ListarProductos();

            return ResuList;

        }

        [HttpGet]
        [Route("api/Producto/FiltrarProductoPorNombre/{dNombre}")]
        public IEnumerable<Products> FiltrarProductoPorNombre(string dNombre)
        {
            BLogica.BL.ListProducts _Proc = new BLogica.BL.ListProducts();

            IEnumerable<Products> ResuList = _Proc.FiltrarProductoPorNombre(dNombre);

            return ResuList;

        }
    }
}