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
        public IEnumerable<_Employees> ListarEmpleados()
        {
            try
            {
                BLogica.BL.Empleados _Proc = new BLogica.BL.Empleados();

                IEnumerable<_Employees> Listado = _Proc.ListarEmpleados();

                return Listado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("api/Empleados/ListarEmpleados/{nombreCompleto?}")]
        public IEnumerable<_Employees> FiltrarEmpleado(string nombreCompleto = "")
        {
            try
            {
                BLogica.BL.Empleados _Proc = new BLogica.BL.Empleados();

                IEnumerable<_Employees> Listado = _Proc.FiltrarEmpleadoPorNombreCompleto(nombreCompleto);

                return Listado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("api/Empleados/guardarEmpleado")]
        public int guardarEmpleado([FromBody] Employees m)
        {
            int sINSERT = 0;

            BLogica.BL.Empleados _Proc = new BLogica.BL.Empleados();

            sINSERT = _Proc.registrarEmpleado(m);

            return sINSERT;
        }
    }
}