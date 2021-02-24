using events_groupe4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace events_groupe4.ViewModels
{
    public class EventCategoryViewModel
    {
        public Event Event { get; set; }
        public IEnumerable<Categorie> EventsCategories { get; set; }


    }
}