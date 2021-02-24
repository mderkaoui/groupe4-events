using events_groupe4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace events_groupe4.Repositories
{
    public class UtilisateurRepository : IUtilisateurRepository
    {
        private MyContext db;

        public UtilisateurRepository(MyContext db)
        {
            this.db = db;
        }


        // ********************************************************************************************
        public int Count(string searchField)
        {
            IQueryable<Utilisateur> req = db.Utilisateurs.AsNoTracking();
            if (searchField != null && !searchField.Trim().Equals(""))
            {
                req = req.Where(u => u.FirstName.ToLower().Contains(searchField)
                         || u.Email.ToLower().Contains(searchField));
            }
            return req.Count();
        }


        // *** DELETE *******************************************************************************************

        public void Delete(int? id)
        {
            db.Utilisateurs.Remove(db.Utilisateurs.Find(id));
            db.SaveChanges();
        }




        //**************************************************************************************************************
        public List<Utilisateur> FindAll(int start, int max, string searchField)
        {
            IQueryable<Utilisateur> req = db.Utilisateurs.AsNoTracking().OrderBy(u => u.FirstName);
            if (searchField != null && !searchField.Trim().Equals(""))
            {
                req = req.Where(u => u.FirstName.ToLower().Contains(searchField)
                         || u.Email.ToLower().Contains(searchField));
            }
            req = req.Skip(start).Take(max);
            return req.ToList();
        }


        //**************************************************************************************************************
        public Utilisateur FindByEmail(string email)
        {
            return db.Utilisateurs.SingleOrDefault(u => u.Email.Equals(email));
        }





        //**************************************************************************************************************
        public Utilisateur FindById(int? id)
        {
            return db.Utilisateurs.AsNoTracking().SingleOrDefault(u => u.Id == id);
        }

        //*** SAVE ***********************************************************************************************************

        public void Save(Utilisateur u)
        {
            db.Utilisateurs.Add(u);
            db.SaveChanges();
        }


        //*** EDIT ************************************************************************************************************
        public void Update(Utilisateur u)
        {
            db.Entry(u).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}