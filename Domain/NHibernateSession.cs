using NHibernate;
using NHibernate.Cfg;

namespace Domain
{
    public class NHibernateSession
    {
        public static ISession OpenSession()
        {
            var configuration = new Configuration().Configure("hibernate.cfg.xml");
            configuration.AddFile("Person.hbm.xml");
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();



            return sessionFactory.OpenSession();
        }
    }
}