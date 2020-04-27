using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BEntidad.BModels;

namespace ArqWeb.EFCore.Controllers
{
    public class EmpleadosController : Controller
    {

        [HttpGet]
        [Route("api/Empleados/ListarEmpleados")]
        public IEnumerable<Employees> ListarEmpleados()
        {
            try
            {
                BLogica.BL.Empleados _Proc = new BLogica.BL.Empleados();

                IEnumerable<Employees> Listado = _Proc.ListarEmpleados();

                return Listado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("api/Empleados/ListarEmpleados/{nombreCompleto?}")]
        public IEnumerable<Employees> FiltrarEmpleado(string nombreCompleto = "")
        {
            try
            {
                BLogica.BL.Empleados _Proc = new BLogica.BL.Empleados();

                IEnumerable<Employees> Listado = _Proc.FiltrarEmpleadoPorNombreCompleto(nombreCompleto);

                return Listado;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}