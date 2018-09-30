using SR.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SR.Model;

namespace SR.Data.Repositories
{
    public class CategoryRepository : IBaseRepository<Category>
    {
        private SRDBContext db;

        public CategoryRepository(SRDBContext db)
        {
            this.db = db;
        }

        public IEnumerable<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            IEnumerable<Category> categories;
            if (filter == null)
            {
                categories = db.Categories.ToList();
            }
            else
            {
                categories = db.Categories.Where(filter).ToList();
            }
            return categories;

        }

        public Category Get(int? id)
        {
            return db.Categories.Find(id);

        }

        public void Create(Category category)
        {
            db.Categories.Add(category);
        }

        public void Update(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Category category = db.Categories.Find(id);
            if (category != null)
                db.Categories.Remove(category);
        }
    }
}
