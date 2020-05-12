using System;
using System.Threading.Tasks;
using Repository.Contract.Entities;
using Repository.Contract.Repositories.Base;

namespace Repository.Contract.Repositories
{
    public interface IUserRepository : IEntityRepository<UserEntity, Guid>
    {
        Task<UserEntity> GetByUserNameAsync(string userName);
    }
}
