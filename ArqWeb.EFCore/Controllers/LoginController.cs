﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BEntidad.BModels;

namespace ArqWeb.EFCore.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
            // View de prueba
        }

        [HttpGet]
        [Route("api/Producto/ListarProductos")]
        public IEnumerable<Products> ListarProductos()
        {
            BLogica.BL.ListProducts _Proc = new BLogica.BL.ListProducts();

            List<Products> ResuList = _Proc.ListarProductos();

            return ResuList;

        }
    }
}