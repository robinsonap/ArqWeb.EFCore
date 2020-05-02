using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BEntidad.BModels;
using BEntidad.BModels_Northwind;

namespace BLogica.BL
{
    public class Categoria
    {

        public IEnumerable<Categories> lsCategoria()
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

        public IEnumerable<_Products> CategoriaPorNombre(int idCategoria)
        {
            using (var _DB = new NorthwindContext())
            {
                IEnumerable<_Products> ProductoPorCategoria = (from t1 in _DB.Products
                                                           join t2 in _DB.Categories
                                                           on t1.CategoryId equals t2.CategoryId
                                                           where t1.CategoryId == idCategoria
                                                           select new _Products
                                                           {
                                                               ProductId = t1.ProductId,
                                                               ProductName = t1.ProductName,
                                                               CategoryId = t1.CategoryId,
                                                               CategoryName = t2.CategoryName
                                                           }).ToList();

                return ProductoPorCategoria;
            }
        }
    }
}
