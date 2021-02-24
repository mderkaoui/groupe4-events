using events_groupe4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace events_groupe4.Services
{
    public interface IUtilisateurService
    {
        Utilisateur CheckLogin(string email, string password);
        List<Utilisateur> FindAll(int page, int maxByPage, string searchField);
        bool NextExist(int page, int maxByPage, string searchField);
        void Save(Utilisateur user);
        Utilisateur Find(int? id);
        void Update(Utilisateur user);
        void Remove(int id);


    }
}
