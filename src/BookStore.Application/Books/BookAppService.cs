using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BookStore.Books
{
    public class BookAppService(IBookRepository repository)
        : CrudAppService<Book, BookDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateBookDto>(repository),
            IBookAppService
    {
        public async Task<string> GetHashAsync(GetHashDto input) 
            => await repository.GetHashAsync(input.TenantId);
    }
}