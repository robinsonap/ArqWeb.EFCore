using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BEntidad.BModels;

namespace BLogica.BL
{
    public class Empleados
    {
        // Agregamos clase

        public IEnumerable<_Employees> ListarEmpleados()
        {
            using (NorthwindContext _DB =  new NorthwindContext())
            {
                IEnumerable<_Employees> rSEmpleados = (from t1 in _DB.Employees
                                               select new _Employees
                                               {
                                                   EmployeeId = t1.EmployeeId,
                                                   NombreCompleto = t1.FirstName + " " + t1.LastName,
                                                   HomePhone = t1.HomePhone,
                                                   BirthDate = t1.BirthDate,
                                                   City = t1.City
                                               }).ToList();

                return rSEmpleados;
            }
        }

        public IEnumerable<_Employees> FiltrarEmpleadoPorNombreCompleto(string nombreCompleto)
        {
            using (NorthwindContext _DB = new NorthwindContext())
            {
                // Si es vacío devolvemos toda la lista.
                if (nombreCompleto == "")
                {
                    IEnumerable<_Employees> rSEmpleados = (from t1 in _DB.Employees
                                                          select new _Employees
                                                          {
                                                              EmployeeId = t1.EmployeeId,
                                                              NombreCompleto = t1.FirstName + " " + t1.LastName,
                                                              HomePhone = t1.HomePhone,
                                                              BirthDate = t1.BirthDate,
                                                              City = t1.City
                                                          }).ToList();

                    return rSEmpleados;
                }
                // Si nombreCompleto 'contiene' valor realiza la búsqueda en BD.
                else
                {
                    IEnumerable<_Employees> rSEmpleados = (from t1 in _DB.Employees
                                                          where (t1.FirstName + " " + t1.LastName).Contains(nombreCompleto)
                                                          select new _Employees
                                                          {
                                                              EmployeeId = t1.EmployeeId,
                                                              NombreCompleto = t1.FirstName + " " + t1.LastName,
                                                              HomePhone = t1.HomePhone,
                                                              BirthDate = t1.BirthDate,
                                                              City = t1.City
                                                          }).ToList();

                    return rSEmpleados;
                }
            }
        }

        public int registrarEmpleado(Employees m)
        {
            int sINSERT = 0;

            using (NorthwindContext _BD = new NorthwindContext())
            {
                try
                {
                    _BD.Add(m);
                    _BD.SaveChanges();

                    sINSERT = 1;

                    return sINSERT;
                }
                catch (Exception ex)
                {
                    sINSERT = 0;

                    return sINSERT;
                }
            }
        }
    }


}
