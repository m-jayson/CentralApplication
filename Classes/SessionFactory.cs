using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Automapping;
using NHibernate.Cfg;

namespace CentralApplication.Classes
{
    class SessionFactory
    {
        public static volatile ISessionFactory sessionFactory;
        private static object syncRoot = new Object();

        public static ISession OpenSession
        {
            get
            {
                if(sessionFactory == null)
                {
                    lock (syncRoot)
                    {
                        if(sessionFactory == null)
                        {
                            sessionFactory = BuildSessionFactory();
                        }
                    }
                }
                return sessionFactory.OpenSession();
            }
        }

        private static ISessionFactory BuildSessionFactory()
        {
            try
            {
                var connectionString = System.Configuration.ConfigurationManager.AppSettings["connection_string"];
                return Fluently.Configure()
                    .Database(MySQLConfiguration.Standard.ConnectionString(connectionString))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
                    .ExposeConfiguration(BuildSchema)
                    .BuildSessionFactory();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                throw e;
            }
        }

        private static AutoPersistenceModel CreateMappings()
        {
            return AutoMap.Assembly(System.Reflection.Assembly.GetCallingAssembly())
                .Where(x => x.Namespace == "CentralApplication.Entities");
        }

        private static void BuildSchema(Configuration config)
        {

        }
    }
}
