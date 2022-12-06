using OnlineBooksCatalogue.Core.Interfaces;
using OnlineBooksCatalogue.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBooksCatalogue.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(OBCDbContext dbContext) : base(dbContext)
        {

        }
    }
}
