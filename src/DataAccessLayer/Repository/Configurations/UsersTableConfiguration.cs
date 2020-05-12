using System;
using Repository.Configurations.Base;
using Repository.Contract.Entities;

namespace Repository.Configurations
{
    public class UsersTableConfiguration : BaseTableConfiguration<UserEntity, Guid>
    {
        public UsersTableConfiguration() : base("Users")
        {
            Property(e => e.UserName).IsRequired();
            Property(e => e.Password).IsRequired();
            HasRequired(e => e.WorkingPosition).WithMany(e => e.Users);
        }
    }
}
