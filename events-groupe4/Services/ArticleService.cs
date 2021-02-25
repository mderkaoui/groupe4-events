using events_groupe4.Models;
using events_groupe4.Repositories;

namespace events_groupe4.Controllers
{
    internal class ArticleService : IArticlesService
    {
        private ArticleRepository articleRepository;
        private ArticleRepository articleRepository1;

        public ArticleService(ArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        //public ArticleService(ArticleRepository articleRepository1)
        //{
          //  this.articleRepository1 = articleRepository1;
        //}

        public Article Find(int? id)
        {
            throw new System.NotImplementedException();
        }

        public object FindAll(int v1, int v2, string v3)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Save(Article article)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Article article)
        {
            throw new System.NotImplementedException();
        }
    }
}