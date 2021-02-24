using events_groupe4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace events_groupe4.Repositories
{
    public interface ICategorieRepository
    {

        List<Categorie> FindAll(int start, int max, string searchField);
        int Count(string searchField);
        void Save(Categorie ctg);
        Categorie FindById(int? id);
        void Update(Categorie ctg);
        void Delete(int? id);

    }
}
