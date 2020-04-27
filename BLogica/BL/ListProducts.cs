using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BEntidad.BModels;

namespace BLogica.BL
{
    public class ListProducts
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
    }
}
