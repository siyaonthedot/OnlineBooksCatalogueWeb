using OnlineBooksCatalogue.Core.Interfaces;
using OnlineBooksCatalogue.Core.Models;
using OnlineBooksCatalogue.Services.Interfaces;
using OnlineBooksCatalogue.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace OnlineBooksCatalogue.Services
{
  
        public class UserService : IUserService
        {
            public OBCDbContext _dbContextd;

        public UserService(OBCDbContext dbContextd)
            {
            _dbContextd = dbContextd;
            }
            public async Task<bool> CreateUser(User user)
            {
                if (user != null)
                {
                    await _dbContextd.Users.AddAsync(user);
                    var result = _dbContextd.SaveChanges();
                    return result > 0 ? true : false;
                }

                return false;
            }

            public async Task<User> GetUserById(int userId)
            {
                return userId < 1 ? null : 
                       await _dbContextd.Users.FirstAsync(s => s.UserId == userId);
            }

            public async Task<User> GetUserByEmail(string email) 
            {
                var result = await _dbContextd.Users.FirstAsync(s=> s.EmailAddress == email); 
                return email != null ? result : null;
            }
            public async Task <IEnumerable<Subscription>> GetUserSubscriptions(int userId) 
            {
                 var subs = await _dbContextd.Subscriptions.Where(s => s.UserId == userId).ToListAsync(); 
                 return subs;

            }

            public async Task<bool> AddUserSubscription(Subscription subscription) 
            {
        
            await _dbContextd.Subscriptions.AddAsync(subscription);
            var result = _dbContextd.SaveChanges();

            return result > 0 ? true : false;
            }   
            public async Task<bool> DeleteUserSubscription(int subId)
        {
            if (subId > 0)
            {
                var subscriptions = await _dbContextd.Subscriptions.FindAsync(subId);
                if (subscriptions != null)
                {
                    _dbContextd.Subscriptions.Remove(subscriptions);
                    var result = _dbContextd.SaveChanges();

                    return result > 0 ? true : false;
                }
            }
            return false;
        }


    }
    
}
