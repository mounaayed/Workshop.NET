using PS.data;
using PS.Data.Infrastructure;
using PS.Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Services
{
    public class ServiceCategory : Service<Category>, IServiceCategorycs

    {
        static DataBaseFactory dbf = new DataBaseFactory();
        UnitOfWork uow = new UnitOfWork(dbf);




        public void Add(Category c)
        {
            uow.getRepository<Category>().Add(c);
        }

        public void Commit()
        {
            uow.Commit();
        }

        public IEnumerable<Category> GetAll()
        {
            return uow.getRepository<Category>().GetAll();
        }

        public void Remove(Category c)
        {
            uow.getRepository<Category>().Delete(c);
        }
    }
}
