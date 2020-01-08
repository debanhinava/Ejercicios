using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Business
{
    public class ProductsN
    {
        private static ProductsD prodD = new ProductsD();
        public static List<Products> ListaProducts()
        {
            return prodD.ListaProducts();

        }

        public static void AgregarProd(Products products)
        {
            prodD.AgregarProd(products);
        }


        public static Products GetProducts(int id)
        {
            return prodD.GetProducts(id);
        }
        public static void Actualizar(Products product)
        {
            prodD.Actualizar(product);

        }

        public static void EliminarLogico(Products product)
        {
            prodD.EliminarLogico(product);
        }

        public static List<Products> BuscaPorNombre(string cadena)
        {
            return prodD.BuscaPorNombre(cadena);
        }
    }
}
