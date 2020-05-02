using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BEntidad.BModels;
using BEntidad.BModels_Northwind;

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
            try
            {
                int sINSERT = 0;

                BLogica.BL.Empleados _Proc = new BLogica.BL.Empleados();

                sINSERT = _Proc.registrarEmpleado(m);

                return sINSERT;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("api/Empleados/recuperarEmpleado/{idPersona}")]
        public _Employees recuperarEmpleado (int idPersona)
        {
            try
            {
                BLogica.BL.Empleados _Proc = new BLogica.BL.Empleados();

                _Employees DatoEmpleado = _Proc.sRecuperarEmpleado(idPersona);

                return DatoEmpleado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("api/Empleados/eliminarEmpleado/{idPersona}")]
        public int eliminarEmpleado (int idPersona)
        {
            try
            {
                int sDELETE = 0;
                BLogica.BL.Empleados _Proc = new BLogica.BL.Empleados();

                sDELETE = _Proc.eliminarEmpleado(idPersona);

                return sDELETE;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}