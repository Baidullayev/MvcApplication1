using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
namespace MvcApplication1.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/
        
        public ActionResult Index()
        {
            List<Product> prod = new List<Product>();
            if (Session["Cart"]!= null)
                prod = Session["Cart"] as List<Product>;

            return View(prod);
        }
        public ActionResult AddToCart(int id)
        {
            List<Product> prod = new List<Product>();
            ProductInfoDAL prodProvider = new ProductInfoDAL();
            if (Session["Cart"] != null)
            {
                prod = Session["Cart"] as List<Product>;
                var SearchResult = prod.Where(x => x.Id == id).FirstOrDefault();
                if (SearchResult != null)
                {
                    return Redirect(Request.QueryString["r"]);
                }
                else 
                {
                    
                    var GetResult = prodProvider.GetProductById(id);
                    prod.Add(GetResult);
                }
            }
            else 
            {
                
                var result = prodProvider.GetProductById(id);
                prod.Add(result);
                Session["Cart"] = prod;
            }

            return Redirect(Request.QueryString["r"]);
            //ProductInfoDAL prodProvider = new ProductInfoDAL();
            //var result = prodProvider.GetProductById(id);            
            //List<Product> prod = new List<Product>();
            //if(Session["Cart"]!=null)
            //{
            //    prod = Session["Cart"] as List<Product>;
            //}
            
            //prod.Add(result);
            //Session["Cart"] = prod;
            //return Redirect(Request.QueryString["r"]);
        }
        public ActionResult DeleteFromCart(int id)
        {
            List<Product> prod = new List<Product>();
            if (Session["Cart"] != null)
            {
                prod = Session["Cart"] as List<Product>;
                var result = prod.Where(x => x.Id == id).FirstOrDefault();
                if (result != null)
                {
                    prod.Remove(result);
                    Session["Cart"] = prod;
                }
            }
            return Redirect(Request.QueryString["r"]);
        }

    }
}
