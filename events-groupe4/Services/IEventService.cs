using events_groupe4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace events_groupe4.Services
{
    public interface IEventService
    {
        List<Event> FindAll(int page, int maxByPage, string searchField);
        bool NextExist(int page, int maxByPage, string searchField);
        void Save(Event evnt);
        Event Find(int? id);
        void Update(Event evnt);
        void Remove(int id);
    }
}
