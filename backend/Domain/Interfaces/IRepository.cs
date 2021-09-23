using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Base;

namespace Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        void Add(TEntity obj, CancellationToken cancellationToken = default);
        Task<TEntity> GetById(int id, CancellationToken cancellationToken = default);
        Task<List<TEntity>> GetAll(CancellationToken cancellationToken = default);
        void Update(TEntity obj, CancellationToken cancellationToken = default);
        void Remove(int id, CancellationToken cancellationToken = default);

    }
}
