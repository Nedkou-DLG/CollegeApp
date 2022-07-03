using System;
using College.Domain.Entities;
using College.Domain.Interfaces;
using College.Domain.Interfaces.Repositories;
using College.Domain.Models.User;

namespace College.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<UserRecord>, IUserRepository
    {
        public UserRepository(CollegeContext context):base(context)
        {
        }

    }
}

