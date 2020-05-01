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
            try
            {
                BLogica.BL.Producto _Proc = new BLogica.BL.Producto();

                IEnumerable<Products> ResuList = _Proc.ListarProductos();

                return ResuList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("api/Producto/FiltrarProductoPorNombre/{dNombre}")]
        public IEnumerable<Products> FiltrarProductoPorNombre(string dNombre)
        {
            try
            {
                BLogica.BL.Producto _Proc = new BLogica.BL.Producto();

                IEnumerable<Products> ResuList = _Proc.FiltrarProductoPorNombre(dNombre);

                return ResuList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("api/Producto/ListarProveedor")]
        public IEnumerable<_Suppliers> ListarProveedor()
        {
            try
            {
                BLogica.BL.Producto _Proc = new BLogica.BL.Producto();

                IEnumerable<_Suppliers> ListadoProveedores = _Proc.ListarProveedor();

                return ListadoProveedores;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("api/Producto/obtenerProductoPorId/{idProducto}")]
        public Products obtenerProductoPorId (int idProducto)
        {
            try
            {
                BLogica.BL.Producto _Proc = new BLogica.BL.Producto();

                Products sProducto = _Proc.obtenerProductoPorId(idProducto);

                return sProducto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("api/Producto/registrarProducto")]
        public int registrarProducto([FromBody] Products m)
        {
            try
            {
                int sINSERT = 0;

                BLogica.BL.Producto _Proc = new BLogica.BL.Producto();

                sINSERT = _Proc.registrarProducto(m);

                return sINSERT;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("api/Producto/eliminarProducto/{idProducto}")]
        public int eliminarProducto (int idProducto)
        {
            try
            {
                int sDELETE = 0;

                BLogica.BL.Producto _Proc = new BLogica.BL.Producto();

                sDELETE = _Proc.eliminarProducto(idProducto);

                return sDELETE;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        [HttpGet]
        [Route("api/Producto/validarNombre/{idProducto}/{nProducto}")]
        public int validarNombre (int idProducto, string nProducto)
        {
            try
            {
                BLogica.BL.Producto _Proc = new BLogica.BL.Producto();
                int sVALIDA = 0;

                sVALIDA = _Proc.validarNombre(idProducto, nProducto);

                return sVALIDA;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}