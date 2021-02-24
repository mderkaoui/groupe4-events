using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace events_groupe4.Models
{
    public class Article
    {

        public int? Id { get; set; }

        [Required]
        [Display(Name = "Organisateur")]
        [ForeignKey("OrganisateurId")]
        public Utilisateur Organisateur { get; set; }

        [Required]
        [Display(Name = "Organisateur")]
        public int? OrganisateurId { get; set; }

        [Required]
        [Display(Name = "Date de parution")]
        public DateTime dateParution { get; set; }

        [Display(Name = "Contenu")]
        public string contenu { get; set; }

        public enum EtatArticle { EN_REDACTION, PUBLIE, DEPRECIE };

        [Display(Name = "Etat")]
        public EtatArticle etat { get; set; }

    }
}