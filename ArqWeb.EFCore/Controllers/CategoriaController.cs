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
            using (var _BD = new NorthwindContext())
            {
                IEnumerable<Categories> listarCate = (from cate in _BD.Categories
                                                      select new Categories
                                                      {
                                                          CategoryId = cate.CategoryId,
                                                          CategoryName = cate.CategoryName
                                                      }).ToList();
                return listarCate;
            }
        }
    }
}