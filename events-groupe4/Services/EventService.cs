using events_groupe4.Models;
using events_groupe4.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace events_groupe4.Services
{
    public class EventService : IEventService
    {

        private IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }



        public Event Find(int? id)
        {
            return _eventRepository.FindById(id);
        }

        public List<Event> FindAll(int page, int maxByPage, string searchField)
        {
            int start = (page - 1) * maxByPage;
            return _eventRepository.FindAll(start, maxByPage, searchField);
        }

        public bool NextExist(int page, int maxByPage, string searchField)
        {
            return (page * maxByPage) < _eventRepository.Count(searchField);
        }

        public void Remove(int id)
        {
            _eventRepository.Delete(id);
        }

        public void Save(Event evnt)
        {
            _eventRepository.Save(evnt);
        }

        public void Update(Event evnt)
        {
            _eventRepository.Update(evnt);
        }
    }
}