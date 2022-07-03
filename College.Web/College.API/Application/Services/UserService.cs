using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using College.API.Application.Interfaces;
using College.API.Helpers;
using College.Domain.Entities;
using College.Domain.Interfaces.Repositories;
using College.Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace College.API.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly AppSettings appSettings;
        public UserService(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            this.unitOfWork = unitOfWork;
            this.appSettings = appSettings.Value;
        }

        public AuthResponse Authenticate(UserLoginRequest model)
        {
            var user = unitOfWork.UserRepository.AsQueryable().Include(x => x.Teacher)
                                                .Include(x => x.Student).FirstOrDefault(x => x.Username == model.Username && x.Password == model.Password);


            if (user == null) return null;

            var token = GenerateJwtToken(user);

            return new AuthResponse(user, token);
        }

        private string GenerateJwtToken(UserRecord user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public IEnumerable<UserRecord> GetAll()
        {
            return unitOfWork.UserRepository.AsEnumerable();
        }

        public UserRecord GetById(int id)
        {
            return unitOfWork.UserRepository.Get(id);
        }
    }
}

