using System;
using Repository.Contexts;
using Repository.Contract.Entities;
using Repository.Contract.Repositories;
using Repository.Repositories.Base;

namespace Repository.Repositories
{
    public class FileBlobRepository : EntityRepository<FileBlobEntity, Guid>, IFileBlobRepository
    {
        public FileBlobRepository(DocManagerDbContext context) : base(context)
        {
        }
    }
}
