using events_groupe4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace events_groupe4.Repositories
{
    public class CategorieRepository : ICategorieRepository
    {

        private MyContext db;

        public CategorieRepository(MyContext db)
        {
            this.db = db;
        }

        public int Count(string searchField)
        {
            IQueryable<Categorie> req = db.Categories.AsNoTracking();
            if (searchField != null && !searchField.Trim().Equals(""))
            {
                req = req.Where(ctg => ctg.Libelle.ToLower().Contains(searchField));
            }
            return req.Count();
        }



        public void Delete(int? id)
        {
            db.Categories.Remove(db.Categories.Find(id));
            db.SaveChanges();
        }



        public List<Categorie> FindAll(int start, int max, string searchField)
        {
            IQueryable<Categorie> req = db.Categories.AsNoTracking().OrderBy(u => u.Libelle);
            if (searchField != null && !searchField.Trim().Equals(""))
            {
                req = req.Where(ctg => ctg.Libelle.ToLower().Contains(searchField));
            }
            req = req.Skip(start).Take(max);
            return req.ToList();
        }





        public Categorie FindById(int? id)
        {
            return db.Categories.AsNoTracking().SingleOrDefault(ctg => ctg.Id == id);
        }






        public void Save(Categorie ctg)
        {
            db.Categories.Add(ctg);
            db.SaveChanges();
        }

        public void Update(Categorie ctg)
        {
            db.Entry(ctg).State = EntityState.Modified;
            db.SaveChanges();
        }


    }
}