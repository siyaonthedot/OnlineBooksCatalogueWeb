
using OnlineBooksCatalogue.Core.Interfaces;
using OnlineBooksCatalogue.Core.Models;
using System;

namespace OnlineBooksCatalogue.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository Books { get; }
        //IUserRepository Users { get; }
        //ISubscriptionRepository Subscriptions { get; }

        int Save();
    }
}
