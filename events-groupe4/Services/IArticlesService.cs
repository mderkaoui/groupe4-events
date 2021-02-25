using events_groupe4.Models;

namespace events_groupe4.Controllers
{
    internal interface IArticlesService
    {
        object FindAll(int v1, int v2, string v3);
        void Save(Article article);
        Article Find(int? id);
        void Remove(int id);
        void Update(Article article);
    }
}