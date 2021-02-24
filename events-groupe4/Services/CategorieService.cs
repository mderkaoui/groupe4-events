using events_groupe4.Models;
using events_groupe4.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace events_groupe4.Services
{
    public class CategorieService : ICategorieService
    {

        private ICategorieRepository _categRepository;

        public CategorieService(ICategorieRepository categRepository)
        {
            _categRepository = categRepository;
        }

        public Categorie Find(int? id)
        {
            return _categRepository.FindById(id);
        }

        public List<Categorie> FindAll(int page, int maxByPage, string searchField)
        {
            int start = (page - 1) * maxByPage;
            return _categRepository.FindAll(start, maxByPage, searchField);
        }

        public bool NextExist(int page, int maxByPage, string searchField)
        {
            return (page * maxByPage) < _categRepository.Count(searchField);
        }

        public void Remove(int id)
        {
            _categRepository.Delete(id);
        }

        public void Save(Categorie categ)
        {
            _categRepository.Save(categ);
        }

        public void Update(Categorie categ)
        {
            _categRepository.Update(categ);
        }
    }
}