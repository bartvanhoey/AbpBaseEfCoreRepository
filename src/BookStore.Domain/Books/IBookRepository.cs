using System;
using BookStore.Domain.Interfaces;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace BookStore.Domain.Books
{
    public interface IBookRepository: IHaveGetHashAsyncRepository<Book, Guid>
    {
        
    }
}
