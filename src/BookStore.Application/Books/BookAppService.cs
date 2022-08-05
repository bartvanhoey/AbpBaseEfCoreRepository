using System;
using System.Threading.Tasks;
using BookStore.Application.Contracts.Books;
using BookStore.Domain.Books;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BookStore.Books
{
    public class BookAppService : CrudAppService<Book, BookDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateBookDto>, IBookAppService
    {
        private readonly IBookRepository _repository;

        public BookAppService(IBookRepository repository) : base(repository) => _repository = repository;

        public async Task<string> GetHashAsync(GetHashDto input) 
            => await _repository.GetHashAsync(input.TenantId);
    }
}
