using AuthenticationAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationAPI.Classes
{
    public class User_MakeDecision
    {
        private UserManager<ApplicationUser> _userManager;

        public User_MakeDecision(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<int> MakeDecision(string email, string password)
        {
            UserFunctions userFunctions = new UserFunctions(_userManager);
            if(await userFunctions.Exist(email) == true)
            {
                return StatusCodes.Status409Conflict;
            }
            else if(await userFunctions.CreateUser(email,password) == true)
            {
                return StatusCodes.Status201Created;
            }
            return StatusCodes.Status500InternalServerError;
        }
    }
}
