using System;
using System.Threading.Tasks;
using BookStore.Application.Contracts.Books;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BookStore.Books
{
    public interface IBookAppService :
        ICrudAppService<BookDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateBookDto>, IApplicationService
    {
        Task<string> GetHashAsync(GetHashDto input);
    }
}