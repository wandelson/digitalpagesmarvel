using NHibernate;
using System.Collections.Generic;

namespace DP.Marvel.Infra.Data.Repository
{
    public class Repository<T> where T : class
    {
        private readonly ISession Session;

        public Repository(ISession session)
        {
            Session = session;
        }

        public IList<T> GetAll()
        {
            return Session.QueryOver<T>().List();
        }

        public void Save(IList<T> characters)
        {
            using (var transaction = Session.BeginTransaction())
            {
                foreach (var item in characters)
                {
                    Session.Save(item);
                }

                transaction.Commit();
            }
        }

        public T Get<T>(int id)
        {
            return Session.Get<T>(id);
        }
    }
}