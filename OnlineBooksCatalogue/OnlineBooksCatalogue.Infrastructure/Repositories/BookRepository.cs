using OnlineBooksCatalogue.Core.Interfaces;
using OnlineBooksCatalogue.Core.Models;

namespace OnlineBooksCatalogue.Infrastructure.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(OBCDbContext dbContext) : base(dbContext)
        {

        }
    }
}
