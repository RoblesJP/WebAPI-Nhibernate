using Domain.Categories;
using NHibernate;
using NHibernate.Linq;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ISession _session;

        public CategoryRepository(ISession session)
        {
            _session = session;
        }

        public async Task<Category> Get(int id)
        {
            return await _session.Query<Category>().Where(x => x.Id == id).SingleAsync();
        }
    }
}
