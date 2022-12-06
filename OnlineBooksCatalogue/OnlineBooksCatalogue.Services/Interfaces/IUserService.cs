using OnlineBooksCatalogue.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBooksCatalogue.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateUser(User user);
        Task<User> GetUserById(int userId);
        Task<IEnumerable<Subscription>> GetUserSubscriptions(int userId);
        Task<bool> AddUserSubscription(Subscription subscription);

        Task<bool> DeleteUserSubscription(int userId);

        Task<User> GetUserByEmail(string email);

       
    }
}
