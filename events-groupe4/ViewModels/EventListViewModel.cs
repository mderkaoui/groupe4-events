using events_groupe4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace events_groupe4.ViewModels
{
    public class EventListViewModel
    {

        public List<Event> Events { get; set; }

        public List<Categorie> EventCategory { get; set; }
    }
}