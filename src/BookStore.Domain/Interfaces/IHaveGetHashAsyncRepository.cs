using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace BookStore.Interfaces
{
    namespace BookStore.Domain.Interfaces
    {
        public interface IHaveGetHashAsyncRepository<TEntity, TKey> : IRepository<TEntity, TKey>
            where TEntity : class, IEntity<TKey>
        {
            Task<string> GetHashAsync(Guid? tenantId);
        }
    }
}