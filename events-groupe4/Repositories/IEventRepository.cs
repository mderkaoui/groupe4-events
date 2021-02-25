using events_groupe4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace events_groupe4.Repositories
{
    public interface IEventRepository
    {
        List<Event> FindAll(int start, int max, string searchField);
        int Count(string searchField);
        void Save(Event evnt);
        Event FindById(int? id);
        void Update(Event evnt);
        void Delete(int? id);
    }
}
