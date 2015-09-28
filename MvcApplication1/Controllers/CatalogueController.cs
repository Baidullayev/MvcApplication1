using MvcApplication1.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class CatalogueController : Controller
    {
        //
        // GET: /Catalogue/

        public ActionResult Index()
        {
            IList<Product> Products;
            using (ISession session = NHibernateHelper2.OpenSession())
            {
                IQuery query = session.CreateQuery("from Product");
                Products = query.List<Product>();
                return View(Products);
            }
        }
        public ActionResult Child()
        {
            IList<Product> Products;
            using (ISession session = NHibernateHelper2.OpenSession())
            {
                IQuery query = session.CreateQuery("from Product where StyleId=1");
                Products = query.List<Product>();
                return View(Products);
            }
        }
        public ActionResult Bed()
        {
            IList<Product> Products;
            using (ISession session = NHibernateHelper2.OpenSession())
            {
                IQuery query = session.CreateQuery("from Product where StyleId=2");
                Products = query.List<Product>();
                return View(Products);
            }
        }
        public ActionResult SoftFurniture()
        {
            IList<Product> Products;
            using (ISession session = NHibernateHelper2.OpenSession())
            {
                IQuery query = session.CreateQuery("from Product where StyleId=3");
                Products = query.List<Product>();
                return View(Products);
            }
        }
        public ActionResult Kitchen()
        {
           
            IList<Product> Products;
            using (ISession session = NHibernateHelper2.OpenSession())
            {
                IQuery query = session.CreateQuery("from Product where StyleId=4");
                Products = query.List<Product>();
                return View(Products);
            }
        }
    }
}
