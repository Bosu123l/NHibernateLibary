using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Domain
{
    public class Manager<T>
    {
        public IEnumerable<T> SellectAll()
        {
            IEnumerable<T> enumerable;
            using (ISession session = NHibernateSession.OpenSession())
            {
                enumerable = session.Query<T>().ToList();
            }

            return enumerable;
        }

        public IEnumerable<T> SellectWhere(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> enumerable;
            using (ISession session = NHibernateSession.OpenSession())
            {
                enumerable = session.Query<T>().Where(predicate).ToList();
            }
            return enumerable;
        }

        public T SellectById(int Id)
        {
            T returnedObject;
            using (ISession session = NHibernateSession.OpenSession())
            {
                returnedObject = session.Get<T>(Id);
            }
            return returnedObject;
        }

        public void Update(int Id, T changedObject)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        T objectToChange = SellectById(Id);

                        objectToChange = changedObject;

                        session.Update(objectToChange, Id);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Add(T newObject)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(newObject);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}