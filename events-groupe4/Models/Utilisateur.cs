using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace events_groupe4.Models
{
    public enum UserRole
    {
        ADMIN,
        ORGANISATEUR,
        ADHERENT
    }



    public class Utilisateur
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire")]
        [Display(Name = "Nom ")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Le prénom est obligatoire")]
        [Display(Name = "Prénom")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "L'adresse email est obligatoire")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Format adresse email invalide")]
        public string Email { get; set; }


        [Required(ErrorMessage = "le mot de passe est obligatoire")]
        [DataType(DataType.Password)]
        public string Password { get; set; }



        [Required(ErrorMessage = "L'adresse est obligatoire")]
        public string Address { get; set; }


        [Required(ErrorMessage = "La ville est obligatoire")]
        [Display(Name = "Ville")]
        public string City { get; set; }



        [Required(ErrorMessage = "La date de naissance est obligatoire")]
        [Display(Name = "Date de naissance")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }


        [Required]
        [Display(Name = "Role")]
        public UserRole Role { get; set; }

        public Utilisateur()
        {
            Role = UserRole.ADHERENT;
        }


    }
}