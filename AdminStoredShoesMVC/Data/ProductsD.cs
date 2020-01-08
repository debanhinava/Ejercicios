using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ProductsD
    {
        DataProductsEntities db = new DataProductsEntities();
        public List<Products> ListaProducts()
        {
            return db.Products.ToList();
        }

        public void AgregarProd(Products products)
        {
            using (var db = new DataProductsEntities())
            {
                db.Products.Add(products);
                db.SaveChanges();
            }
        }

        public Products GetProducts(int id)
        {
            using (var db = new DataProductsEntities())
            {
                return db.Products.Find(id);

            }
        }


        public void Actualizar(Products product)
        {
            using (var db = new DataProductsEntities())
            {
                var d = db.Products.Find(product.Id);
                d.IdBrand = product.IdBrand;
                d.IdCatalog = product.IdCatalog;
                d.IdColor = product.IdColor;
                d.IdProvider = product.IdProvider;
                d.IdType = product.IdType;
                d.IsEnabled = product.IsEnabled;
                d.Keywords = product.Keywords;
                d.PriceMember = product.PriceMember;
                d.PriceDistributor = product.PriceDistributor;
                d.PriceClient = product.PriceClient;
                d.Nombre = product.Nombre;
                d.Observations = product.Observations;
                d.DateUpdate = product.DateUpdate;
                d.Title = product.Title;
                d.Description = product.Description;
                db.SaveChanges();

            }
        }

    }
}
