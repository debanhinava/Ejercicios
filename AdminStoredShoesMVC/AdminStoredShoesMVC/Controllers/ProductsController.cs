using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Data;

namespace AdminStoredShoesMVC.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {

            var products = ProductsN.ListaProducts();
            return View(products);
        }

        [HttpGet] //solicita info al servidor
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Products products)
        {
            try
            {
                ProductsN.AgregarProd(products);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(products);
            }
        }

        public ActionResult GetProducts (int id)
        {
            var produ = ProductsN.GetProducts(id);
            return View(produ);
        }

        public ActionResult Actualizar(int id)
        {
            var product = ProductsN.GetProducts(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Actualizar(Products products)
        {
            try
            {
                ProductsN.Actualizar(products);
                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {

                ModelState.AddModelError("", "error");
                return View(products);
            }
        }

        public ActionResult EliminarLogico (int id)
        {
            var product = ProductsN.GetProducts(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult EliminarLogico(Products products)
        {
            try
            {
                ProductsN.EliminarLogico(products);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "error");
                return View(products);
            }
           
        }

        //INTENTO DE BUSQUEDA PPOR NOMBRE #1

        public ActionResult BuscaPorNombre(string cadena="")
        {
            //cadena = "Adidas";
            var products = ProductsN.BuscaPorNombre(cadena);
            return View(products);
        }

    }
}