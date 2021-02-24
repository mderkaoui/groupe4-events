using events_groupe4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace events_groupe4.Services
{
    public interface ICategorieService
    {


        List<Categorie> FindAll(int page, int maxByPage, string searchField);
        bool NextExist(int page, int maxByPage, string searchField);
        void Save(Categorie categ);
        Categorie Find(int? id);
        void Update(Categorie categ);
        void Remove(int id);


    }
}
