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
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IUserRepository userRepository;

        public UserServices(IHttpContextAccessor _httpContextAccessor,
            IUserRepository _userRepository)
        {
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
                new Claim(ClaimTypes.Name, request.Email)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await context.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity)
                );
        }

        public User GetUserById(int id)
        {
            return userRepository.GetById(id);
        }

        public List<User> GetUsers(GetUsersRequest request)
        {
            return userRepository.GetUsers(request);
        }

        public void UpdateUser(UpdateUserRequest request)
        {
            var user = userRepository.GetById(request.Id);
            user.Name = request.Name;
            userRepository.Update(user);
        }
    }
}