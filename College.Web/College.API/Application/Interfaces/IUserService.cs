using System;
using College.Domain.Entities;
using College.Domain.Models.User;

namespace College.API.Application.Interfaces
{
    public interface IUserService
    {
        AuthResponse Authenticate(UserLoginRequest model);
        IEnumerable<UserRecord> GetAll();
        UserRecord GetById(int id);
    }
}

