
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
namespace MvcApplication1.Models
{
    public static class NHibernateHelper
    {
        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
           .Database(MsSqlConfiguration.MsSql2012
           .ConnectionString(c => c
           .Server("ABYLAIKHAN\\SQLEXPRESS")
           .Database("store")
           //.TrustedConnection()
           
                .Username("sa") 
                .Password("12345678")
                )
                ) 
           .Mappings(m => m
           .FluentMappings
           .AddFromAssemblyOf<Product>()
           .AddFromAssemblyOf<Style>()
           .AddFromAssemblyOf<Firm>()
           .AddFromAssemblyOf<Order>()
           ).ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
           //).ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false,true))
           .BuildSessionFactory();


        }
     //   public static ISession OpenSession()
     //   {
     //       ISessionFactory sessionFactory = Fluently.Configure()
     //           //Настройки БД. Строка подключения к БД MS Sql Server 2008
     //.Database(MsSqlConfiguration.MsSql2012.ConnectionString("Server=(local)\\SQLEXPRESS; database=store;user=sa;password=12345678;")
            
     //       )
     //           //Маппинг. Используя AddFromAssemblyOf NHibernate будет пытаться маппить КАЖДЫЙ класс в этой сборке (assembly). Можно выбрать любой класс. 
     //       .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Product>().AddFromAssemblyOf<Order>().AddFromAssemblyOf<Style>().AddFromAssemblyOf<Firm>())
     //           //SchemeUpdate позволяет создавать/обновлять в БД таблицы и поля (2 поле ==true) 
     //       .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true))
     //       .BuildSessionFactory();
     //       return sessionFactory.OpenSession();
     //   }
    }
}