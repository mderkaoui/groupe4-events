using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace events_groupe4.Models
{
    public class Reservation
    {
        public int? Id { get; set; }

        [ForeignKey("EvenementId")]
        public Event Evenement { get; set; }
        public int? EvenementId { get; set; }

        public DateTime DateCreation { get; set; }

        [ForeignKey("AdherentId")]
        public Utilisateur Adherent { get; set; }
        public int? AdherentId { get; set; }
    }
}