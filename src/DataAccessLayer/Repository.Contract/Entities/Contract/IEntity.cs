using System;

namespace Repository.Contract.Entities.Contract
{
    public interface IEntity<T> where T : IEquatable<T>
    {
        T Id { get; set; }
    }
}
