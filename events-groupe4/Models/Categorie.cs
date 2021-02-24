using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace events_groupe4.Models
{
    public enum TypeEvent
    {

        CULTURE,
        SPORT

    }


    public class Categorie
    {

        public int? Id { get; set; }


        [Required]
        [Display(Name = "Libelle")]
        public string Libelle { get; set; }


        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }


        [Required]
        [Display(Name = "Type")]
        public TypeEvent Type { get; set; }


    }
}