using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
namespace MvcApplication1.Controllers
{
    public class ProductInfoController : Controller
    {
        //
        // GET: /ProductInfo/
        ProductInfoDAL objProduct;

        public ProductInfoController()
        {
            objProduct = new ProductInfoDAL();
        }
        public ActionResult Index()
        {
            var products = objProduct.GetProducts();
            return View(products);
        }
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            var product = new Product();
            return View(product);
        }
        public ActionResult Create(Product newProduct)
        {
            try
            {
                objProduct.CreateProduct(newProduct);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var product = objProduct.GetProductById(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var product = objProduct.GetProductById(id);
                objProduct.DeleteProduct(product);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
