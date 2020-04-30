using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BEntidad.BModels;

namespace BLogica.BL
{
    public class Producto
    {
        public IEnumerable<Products> ListarProductos()
        {
            using (NorthwindContext _DB = new NorthwindContext())
            {
                IEnumerable<Products> Lista = (from t1 in _DB.Products
                                        join t2 in _DB.Categories
                                        on t1.CategoryId equals t2.CategoryId
                                        select new Products
                                        { 
                                        ProductId = t1.ProductId,
                                        ProductName = t1.ProductName,
                                        CategoryId = t1.CategoryId,
                                        CategoryName = t2.CategoryName
                                        }).ToList();

                return Lista;
            }
        }

        public IEnumerable<Products> FiltrarProductoPorNombre(string dNombre)
        {
            using (NorthwindContext _DB = new NorthwindContext())
            {
                IEnumerable<Products> Lista = (from t1 in _DB.Products
                                        join t2 in _DB.Categories
                                        on t1.CategoryId equals t2.CategoryId
                                        where t1.ProductName.Contains(dNombre)
                                        select new Products
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
    }
}
