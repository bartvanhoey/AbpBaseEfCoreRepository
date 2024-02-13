using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BookStore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using static System.String;
using static System.Text.Encoding;

namespace BookStore.BaseEfCoreRepo
{
    public abstract class BaseEfCoreRepository<TEntity, TKey>(IDbContextProvider<BookStoreDbContext> dbContextProvider)
        : EfCoreRepository<BookStoreDbContext, TEntity>(dbContextProvider),
            IBasicRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        protected string ComputeHash(IEnumerable<string> strings)
        {
            var items = strings.ToList();
            if (items.Count == 0)
            {
                return Empty;
            }

            using var sha1 = SHA1.Create();
            var bytes = sha1.ComputeHash(UTF8.GetBytes(Concat(items)));
            var builder = new StringBuilder(bytes.Length * 2);
            foreach (var b in bytes) // can be "x2" if you want lowercase
            {
                builder.Append(b.ToString("X2"));
            }

            return builder.ToString();
        }

        public async Task DeleteAsync(TKey id, bool autoSave = false, CancellationToken cancellationToken = default)
            => await base.DeleteAsync(x => x.Id.Equals(id), autoSave, cancellationToken);

        public async Task DeleteManyAsync(IEnumerable<TKey> ids, bool autoSave = false,
            CancellationToken cancellationToken = default)
        {
            var entities = await (await GetDbSetAsync()).Where(x => ids.Contains(x.Id)).ToListAsync(cancellationToken);
            await base.DeleteManyAsync(entities, autoSave, cancellationToken);
        }

        public async Task<TEntity?> FindAsync(TKey id, bool includeDetails = true,
            CancellationToken cancellationToken = default)
            => await base.FindAsync(x => x.Id.Equals(id), includeDetails, cancellationToken);

        public async Task<TEntity> GetAsync(TKey id, bool includeDetails = true,
            CancellationToken cancellationToken = default)
            => await base.GetAsync(x => x.Id.Equals(id), includeDetails, cancellationToken);
    }
}