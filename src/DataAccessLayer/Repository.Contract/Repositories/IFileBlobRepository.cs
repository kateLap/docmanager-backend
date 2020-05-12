﻿using System;
using Repository.Contract.Entities;
using Repository.Contract.Repositories.Base;

namespace Repository.Contract.Repositories
{
    public interface IFileBlobRepository : IEntityRepository<FileBlobEntity, Guid>
    {
    }
}
