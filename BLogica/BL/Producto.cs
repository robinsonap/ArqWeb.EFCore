using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BEntidad.BModels;
using BEntidad.BModels_Northwind;

namespace BLogica.BL
{
    public class Producto
    {
        public IEnumerable<_Products> ListarProductos()
        {
            using (NorthwindContext _DB = new NorthwindContext())
            {
                IEnumerable<_Products> Lista = (from t1 in _DB.Products
                                        join t2 in _DB.Categories
                                        on t1.CategoryId equals t2.CategoryId
                                        select new _Products
                                        { 
                                        ProductId = t1.ProductId,
                                        ProductName = t1.ProductName,
                                        CategoryId = t1.CategoryId,
                                        CategoryName = t2.CategoryName
                                        }).ToList();

                return Lista;
            }
        }

        public IEnumerable<_Products> FiltrarProductoPorNombre(string dNombre)
        {
            using (NorthwindContext _DB = new NorthwindContext())
            {
                IEnumerable<_Products> Lista = (from t1 in _DB.Products
                                        join t2 in _DB.Categories
                                        on t1.CategoryId equals t2.CategoryId
                                        where t1.ProductName.Contains(dNombre)
                                        select new _Products
                                        {
                                            ProductId = t1.ProductId,
                                            ProductName = t1.ProductName,
                                            CategoryId = t1.CategoryId,
                                            CategoryName = t2.CategoryName
                                        }).ToList();

                return Lista;
            }
        }

        public IEnumerable<_Suppliers> ListarProveedor()
        {
            using (NorthwindContext _DB = new NorthwindContext())
            {
                IEnumerable<_Suppliers> ListadoProveedores = (from t1 in _DB.Suppliers
                                                       select new _Suppliers
                                                       { 
                                                       SupplierId = t1.SupplierId,
                                                       CompanyName = t1.CompanyName
                                                       }).ToList();

                return ListadoProveedores;
            }
        }

        public Products obtenerProductoPorId (int idProducto)
        {
            using (NorthwindContext _DB = new NorthwindContext())
            {
                Products sProducto = (from t1 in _DB.Products
                                      where t1.ProductId == idProducto
                                      select new Products 
                                      { 
                                      ProductId = t1.ProductId,
                                      ProductName = t1.ProductName,
                                      UnitPrice = t1.UnitPrice,
                                      SupplierId = t1.SupplierId,
                                      CategoryId = t1.CategoryId,
                                      UnitsInStock = t1.UnitsInStock
                                      }).First();

                return sProducto;
            }
        }

        public int registrarProducto (Products m)
        {
            int sINSERT = 0;

            using (NorthwindContext _BD = new NorthwindContext())
            {
                try
                {
                    if (m.ProductId == 0)
                    {
                        _BD.Add(m);
                        _BD.SaveChanges();

                        sINSERT = 1;
                    }
                    else
                    {
                        Products sProductos = _BD.Products.Where(p => p.ProductId == m.ProductId).First();
                        sProductos.ProductId = m.ProductId;
                        sProductos.ProductName = m.ProductName;
                        sProductos.UnitPrice = m.UnitPrice;
                        sProductos.SupplierId = m.SupplierId;
                        sProductos.CategoryId = m.CategoryId;
                        sProductos.UnitsInStock = m.UnitsInStock;
                        _BD.SaveChanges();

                        sINSERT = 1;
                    }
                }
                catch (Exception)
                {
                    sINSERT = 0;
                }

                return sINSERT;
            }
        }

        public int eliminarProducto (int idProducto)
        {
            int sDELETE = 0;

            using (NorthwindContext _BD = new NorthwindContext())
            {
                try
                {
                    Products EliminaProducto = _BD.Products.Where(p => p.ProductId == idProducto).First();
                    EliminaProducto.ProductId = idProducto;
                    _BD.Products.Remove(EliminaProducto);
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

        public int validarNombre(int idProducto, string nProducto)
        {
            int sVALIDA = 0;

            using (NorthwindContext _BD = new NorthwindContext())
            {
                try
                {
                    if ( idProducto == 0)
                    {
                        sVALIDA = _BD.Products.Where(p => p.ProductName.ToLower() == nProducto.ToLower()).Count();
                    }
                    else
                    {
                        sVALIDA = _BD.Products.Where(p => p.ProductName.ToLower() == nProducto.ToLower() && p.ProductId != idProducto).Count();
                    }
                }
                catch (Exception)
                {
                    sVALIDA = 0;
                }

                return sVALIDA;
            }
        }
    }
}
