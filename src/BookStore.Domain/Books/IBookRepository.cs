using System;
using BookStore.Interfaces.BookStore.Domain.Interfaces;

namespace BookStore.Books
{
    public interface IBookRepository : IHaveGetHashAsyncRepository<Book, Guid>;
}