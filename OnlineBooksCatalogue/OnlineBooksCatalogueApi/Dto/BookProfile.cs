using AutoMapper;
using OnlineBooksCatalogueApi.ViewModels;
using OnlineBooksCatalogue.Core.Models;
namespace OnlineBooksCatalogueApi.Dto
  
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
        CreateMap<BookModel, Book>();
        }
    }

    public class UserProfile : Profile
    {

        public UserProfile()
        {
            CreateMap<UserMode, User>();
        }
    }

    public class SubscriptionModelProfile : Profile
    {
        public SubscriptionModelProfile()
        {
            CreateMap<SubscriptionModel, Subscription>();
        }
    }
}
