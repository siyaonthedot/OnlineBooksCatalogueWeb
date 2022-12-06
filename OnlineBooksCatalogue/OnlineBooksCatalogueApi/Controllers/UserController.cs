using Microsoft.AspNetCore.Mvc;
using OnlineBooksCatalogue.Core.Models;
using OnlineBooksCatalogueApi.ViewModels;
using OnlineBooksCatalogue.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using OnlineBooksCatalogue.Services.Interfaces;
using System.Net.Mail;

namespace OnlineBooksCatalogueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        public readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper) 
        { 
                this._userService = userService;
                this._mapper = mapper;
        }

        [HttpPost]
        [Route("UserRegistration")]
        public async Task<IActionResult> UserRegistration(UserMode model)
        {
            var UserDetails = _mapper.Map<User>(model);
            var isUserCreated = await _userService.CreateUser(UserDetails);

            return isUserCreated == true ?
                   Ok(isUserCreated) : isUserCreated == false ?
                    BadRequest() : BadRequest();
        }

        [HttpGet]
        [Route("GetUserByEmail")]
        public async Task<IActionResult> GetUserByEmail(string emailAddress)
        {      
            var user = await _userService.GetUserByEmail(emailAddress);

            return Ok(user);
        }

        [HttpPost]
        [Route("AddUserSubscription")]
        public async Task<IActionResult> AddUserSubscription(SubscriptionModel model)
        {
            var subscrDetails = _mapper.Map<Subscription>(model);
            var isSubscrtCreated = await _userService.AddUserSubscription(subscrDetails);

            return isSubscrtCreated == true ?
                   Ok(isSubscrtCreated) : isSubscrtCreated == false ?
                    BadRequest() : BadRequest();
        }

        [HttpDelete("{substriptionId}", Name = "DeleteUserSubscription")]
        public async Task<IActionResult> DeleteUserSubscription(int substriptionId)
        {
            var isSubstriptionDeleted = await _userService.DeleteUserSubscription(substriptionId);

            return isSubstriptionDeleted == true ? Ok(isSubstriptionDeleted) :
                   isSubstriptionDeleted == false ? BadRequest() : BadRequest();

        }


    }
}
