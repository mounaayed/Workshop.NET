using PS.Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Services
{
   public interface IServiceCategorycs :IService<Category>
    {
        void Add(Category c);
        void Remove(Category c);
        IEnumerable<Category> GetAll();
        void Commit();

    }
}
