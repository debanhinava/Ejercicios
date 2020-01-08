using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace Data
{
    public class ProductsD
    {
        
        public List<Products> ListaProducts()
        {
            using (DataProductsEntities db = new DataProductsEntities())
            {
                //return db.Products.ToList();
                return db.Products.Where (p=> p.IsEnabled == true).ToList();
            }

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
                d.IdType = product.IdType;
                d.IdColor = product.IdColor;
                d.IdBrand = product.IdBrand;
                d.IdProvider = product.IdProvider;
                d.IdCatalog = product.IdCatalog;
                d.Title = product.Title;
                d.Nombre = product.Nombre;
                d.Description = product.Description;
                d.Observations = product.Observations;
                d.PriceDistributor = product.PriceDistributor;
                d.PriceClient = product.PriceClient;
                d.PriceMember = product.PriceMember;
                d.IsEnabled = product.IsEnabled;
                d.Keywords = product.Keywords;
                d.DateUpdate = product.DateUpdate;

                db.SaveChanges();

            }
        }
        public void EliminarLogico (Products product)
        {
            using (var db = new DataProductsEntities())
            {
                var d = db.Products.Find(product.Id);
                d.IsEnabled = false;
                product.IsEnabled = false;
                //db.Entry(d).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        //intento de busqueda por nombre
        //public Products GetProducts(string nombre)
        //{
        //    using (var db = new DataProductsEntities())
        //    {
        //        return db.Products.Find(nombre);

        //    }
        //}

        public List<Products> BuscaPorNombre(string cadena)
        {
            using(var db = new DataProductsEntities())
            {
                return db.Products.Where(p => p.Nombre.Contains(cadena)).ToList();
            }
        }

    }
}
