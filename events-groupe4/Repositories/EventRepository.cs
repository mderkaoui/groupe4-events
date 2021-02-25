using events_groupe4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace events_groupe4.Repositories
{
    public class EventRepository : IEventRepository
    {
        private MyContext db;

        public EventRepository(MyContext db)
        {
            this.db = db;
        }
        public int Count(string searchField)
        {
            IQueryable<Event> req = db.Events.AsNoTracking();
            if (searchField != null && !searchField.Trim().Equals(""))
            {
                req = req.Where(evt => evt.Titre.ToLower().Contains(searchField));
            }
            return req.Count();
        }

        public void Delete(int? id)
        {
            db.Events.Remove(db.Events.Find(id));
            db.SaveChanges();
        }

        public List<Event> FindAll(int start, int max, string searchField)
        {
            IQueryable<Event> req = db.Events.AsNoTracking().OrderBy(u => u.Titre);
            if (searchField != null && !searchField.Trim().Equals(""))
            {
                req = req.Where(evt => evt.Titre.ToLower().Contains(searchField));
            }
            req = req.Skip(start).Take(max);
            return req.ToList();
        }

        public Event FindById(int? id)
        {
            return db.Events.AsNoTracking().SingleOrDefault(evt => evt.Id == id);
        }

        public void Save(Event evnt)
        {
            db.Events.Add(evnt);
            db.SaveChanges();
        }

        public void Update(Event evnt)
        {
            db.Entry(evnt).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}