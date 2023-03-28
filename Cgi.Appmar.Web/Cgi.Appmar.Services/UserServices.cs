using Cgi.Appmar.Interfaces.Repositories;
using Cgi.Appmar.Interfaces.Services;
using Cgi.Appmar.Models.Requests;
using Cgi.Appmar.Utils.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Cgi.Appmar.Services
{
    public class UserServices : IUserServices
    {
        private readonly IVesselRepository vesselRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IUserRepository userRepository;

        public UserServices(IVesselRepository _vesselRespotirory, 
            IHttpContextAccessor _httpContextAccessor,
            IUserRepository _userRepository)
        {
            vesselRepository = _vesselRespotirory;
            httpContextAccessor = _httpContextAccessor;
            userRepository = _userRepository;
        }

        public User AddUser(AddUserRequest request)
        {
            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                PasswordHash = Hashing.Hash(request.Password),
                CreateDate = DateTime.UtcNow,
                IsActive = true
            };

            userRepository.Add(user);

            return user;
        }

        public async void Authenticate(AuthenticateRequest request)
        {
            var context = httpContextAccessor.HttpContext;
            var username = request.Email;
            var passwordHash = Hashing.Hash(request.Password);

            var user = new User
            {
                Email = username,
                PasswordHash = passwordHash,
            };

            if (!userRepository.IsValidUser(user))
            {
                throw new Exception();
            }

            var claims = new List<Claim>
            {
                new Claim(type: ClaimTypes.Email, value: request.Email),
                new Claim(type: ClaimTypes.Name,value: request.Password)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await context.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity),
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    AllowRefresh = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                });
        }
    }
}