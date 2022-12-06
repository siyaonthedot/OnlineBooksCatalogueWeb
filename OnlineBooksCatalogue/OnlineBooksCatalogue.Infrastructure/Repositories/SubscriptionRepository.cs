using OnlineBooksCatalogue.Core.Interfaces;
using OnlineBooksCatalogue.Core.Models;

namespace OnlineBooksCatalogue.Infrastructure.Repositories
{
    public class SubscriptionRepository : GenericRepository<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(OBCDbContext dbContext) : base(dbContext)
        {

        }
    }
}
