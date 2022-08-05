using System;
using System.Linq;
using System.Threading.Tasks;
using BookStore.BaseEfCoreRepo;
using BookStore.Domain.Books;
using Volo.Abp.EntityFrameworkCore;

namespace BookStore.EntityFrameworkCore.Books
{
    public class BookRepository : BaseEfCoreRepository<Book, Guid>, IBookRepository
    {
        public BookRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<string> GetHashAsync(Guid? tenantId)
        {
            using var disposable = CurrentTenant.Change(tenantId);
            return ComputeHash((await GetDbContextAsync()).Books.Select(x => $"{x.Id}{x.Name}{x.Type}{x.PublishDate}{x.Price}"));
        }
 
    }
}
