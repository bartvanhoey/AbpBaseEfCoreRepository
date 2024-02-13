using System;
using System.Linq;
using System.Threading.Tasks;
using BookStore.BaseEfCoreRepo;
using BookStore.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace BookStore.Books
{
    public class BookRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider)
        : BaseEfCoreRepository<Book, Guid>(dbContextProvider), IBookRepository
    {
        public async Task<string> GetHashAsync(Guid? tenantId)
        {
            using var disposable = CurrentTenant.Change(tenantId);
            return ComputeHash(
                (await GetDbContextAsync()).Books.Select(x => $"{x.Id}{x.Name}{x.Type}{x.PublishDate}{x.Price}"));
        }
    }
}