using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;

namespace HibTest
{
    public class NhibernateDataProvider
    {
        public Person getPersonByID(int ID)
        {
            ISessionFactory sessionFactory = new Configuration().Configure("hibernate.cfg.xml").BuildSessionFactory();
            ISession session = sessionFactory.OpenSession();

            return session.Get<Person>(ID);
        }
    }
}