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
        public CategoryRepository()
        {

        }

        public IEnumerable<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            using (SRDBContext db = new SRDBContext())
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
        }

        public Category Get(int? id)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.Categories.Find(id);
            }
        }

        public void Create(Category category)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.Categories.Add(category);
            }
        }

        public void Update(Category category)
        {
            using (SRDBContext db = new SRDBContext())
            {
                db.Entry(category).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            using (SRDBContext db = new SRDBContext())
            {
                Category category = db.Categories.Find(id);
                if (category != null)
                    db.Categories.Remove(category);
            }
        }
    }
}
