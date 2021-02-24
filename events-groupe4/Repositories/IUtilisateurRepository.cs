using events_groupe4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace events_groupe4.Repositories
{
    public interface IUtilisateurRepository
    {

        List<Utilisateur> FindAll(int start, int max, string searchField);
        Utilisateur FindByEmail(string email);
        int Count(string searchField);
        void Save(Utilisateur u);
        Utilisateur FindById(int? id);
        void Update(Utilisateur u);
        void Delete(int? id);

    }
}
