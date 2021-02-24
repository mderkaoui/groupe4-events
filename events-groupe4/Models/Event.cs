using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace events_groupe4.Models
{
    public class Event
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Le titre est obligatoire")]
        [Display(Name = "Titre")]
        public string Titre { get; set; }


        [Required(ErrorMessage = "La description est obligatoire")]
        [Display(Name = "Description")]
        public string description { get; set; }

        [Display(Name = "Date de création")]
        [DataType(DataType.Date)]
        public DateTime DateDebut { get; set; }

        [Display(Name = "Date de fin")]
        [DataType(DataType.Date)]
        public DateTime DateFin { get; set; }

        [Display(Name = "Public")]
        public bool publie { get; set; }


        ////Many Event to One Category
        [ForeignKey("categorieId")]
        public Categorie categorie { get; set; }
        public int? categorieId { get; set; }

        [FileExtensions(Extensions = "png, jpg, jpeg")]
        public string Photo { get; set; }

    }
}