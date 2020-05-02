using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BEntidad.BModels_Northwind;
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
                    if (m.EmployeeId == 0)
                    {
                        _BD.Add(m);
                        _BD.SaveChanges();

                        sINSERT = 1;
                    }
                    else
                    {
                        //Recuperar toda la fila
                        Employees sEmpleados = _BD.Employees.Where(p => p.EmployeeId == m.EmployeeId).First();
                        sEmpleados.LastName = m.LastName;
                        sEmpleados.FirstName = m.FirstName;
                        sEmpleados.HomePhone = m.HomePhone;
                        sEmpleados.City = m.City;
                        sEmpleados.BirthDate = m.BirthDate;
                        _BD.SaveChanges();

                        sINSERT = 1;
                    }
                }
                catch (Exception ex)
                {
                    sINSERT = 0;

                }

                return sINSERT;
            }
        }

        public _Employees sRecuperarEmpleado(int idPersona)
        {
            using (NorthwindContext _BD = new NorthwindContext())
            {
                _Employees DatoEmpleado = (from t1 in _BD.Employees
                                           where t1.EmployeeId == idPersona
                                           select new _Employees
                                           {
                                               EmployeeId = t1.EmployeeId,
                                               LastName = t1.LastName,
                                               FirstName = t1.FirstName,
                                               HomePhone = t1.HomePhone,
                                               City = t1.City,
                                               fechaCadena = t1.BirthDate != null ? ((DateTime)t1.BirthDate).ToString("yyyy-MM-dd") : ""
                                           }).First();

                return DatoEmpleado;
            }
        }

        public int eliminarEmpleado (int idPersona)
        {
            int sDELETE = 0;

            using (NorthwindContext _BD = new NorthwindContext())
            {
                try
                {
                    Employees EliminaEmpleado = _BD.Employees.Where(p => p.EmployeeId == idPersona).First();
                    EliminaEmpleado.EmployeeId = idPersona;
                    _BD.Employees.Remove(EliminaEmpleado);
                    _BD.SaveChanges();

                    sDELETE = 1;
                }
                catch (Exception)
                {
                    sDELETE = 0;
                }

                return sDELETE;
            }
        }
    }


}
