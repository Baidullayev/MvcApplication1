using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class ProductInfoDAL
    {
        ISessionFactory sessionFactory;
        ISession OpenSession()
        {

            if (sessionFactory == null)
            {
                sessionFactory = NHibernateHelper.CreateSessionFactory();                
            }
            return sessionFactory.OpenSession();
        }
        public IList<Product> GetProducts()
        {
            IList<Product> Products;
            using (ISession session = OpenSession())
            {
                IQuery query = session.CreateQuery("from Product");
                Products = query.List<Product>();
            }
            return Products;
        }
        public Product GetProductById(int id)
        {
            Product oneProduct = new Product();
            using(ISession session = OpenSession())
            {
                oneProduct = session.Get<Product>(id);
            }
            return oneProduct;
        }
        public IList<Product> GetProductByStyleId(int styleId)
        {
            IList<Product> products;
            using (ISession session = OpenSession())
            {
                IQuery query = session.CreateQuery("From Product where StyleId = '" + Convert.ToString(styleId) + "'");
                products = query.List<Product>();
            }
            return products;
        }
        public IList<Product> GetProductRealizeTime(DateTime startDate, DateTime endDate)
        {
            IList<Product> products;
            using (ISession session = OpenSession())
            {
                IQuery query = session.CreateSQLQuery("Select * From Product Where realizeTime Between " + "'" +  startDate + "'" + "AND" + endDate + "'");
                products = query.List<Product>();
            }
            return products;
        }
        public IList<Product> GetDiscountProducts()
        {
            IList<Product> products;
            using (ISession session = OpenSession())
            {
                IQuery query = session.CreateSQLQuery("Select * From Product Where HasDiscount IS NOT NULL");
                products = query.List<Product>();
            }
            return products;
        }

        public String CreateProduct(Product newProduct)
        {
            String result;
            using (ISession session = OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(newProduct);
                        transaction.Commit();
                        result = "New product successfully created!";
                    }
                    catch (HibernateException e)
                    {
                        transaction.Rollback();
                        result = e.Message;
                        throw;
                    }
                }
                return result;
            }
        }

        public String UpdateProduct(Product changedProduct)
        {
            String result;
            using (ISession session = OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(changedProduct);
                        transaction.Commit();
                        result = "Product successfully updated!";
                    }
                    catch (HibernateException e)
                    {
                        transaction.Rollback();
                        result = e.Message;
                        throw;
                    }
                }
                return result;
            }
        }
        public String DeleteProduct(Product product)
        {
            String result;
            using (ISession session = OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(product);
                        transaction.Commit();
                        result = "Product successfully deleted!";
                    }
                    catch (HibernateException e)
                    {
                        transaction.Rollback();
                        result = e.Message;
                        throw;
                    }
                }
                return result;
            }
        }



    }
}