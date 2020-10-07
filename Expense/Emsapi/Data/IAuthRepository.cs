using Emsapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emsapi.Data
{
    interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string Username, string password);
        Task<bool> UserExists(string username);
    }
}