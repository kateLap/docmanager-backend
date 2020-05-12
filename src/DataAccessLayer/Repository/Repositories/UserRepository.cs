using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Repository.Contexts;
using Repository.Contract.Entities;
using Repository.Contract.Repositories;
using Repository.Repositories.Base;

namespace Repository.Repositories
{
    public class UserRepository : EntityRepository<UserEntity, Guid>, IUserRepository
    {
        public UserRepository(DocManagerDbContext context) : base(context)
        {
        }

        public async Task<UserEntity> GetByUserNameAsync(string userName)
        {
            return await GetAll().SingleOrDefaultAsync(user => user.UserName == userName);
        }
    }
}
