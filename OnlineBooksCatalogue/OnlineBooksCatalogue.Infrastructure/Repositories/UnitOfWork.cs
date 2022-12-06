using System;
using OnlineBooksCatalogue.Core.Interfaces;

namespace OnlineBooksCatalogue.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OBCDbContext _dbContext;
        public IBookRepository Books { get; }
 
        public UnitOfWork(OBCDbContext dbContext, IBookRepository bookRepository)
        {
            _dbContext = dbContext;
            Books = bookRepository;
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

    }
}
