using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApp
{
    internal class BookService
    {
        public ObservableCollection<Book> books { get; } = new ObservableCollection<Book>();
        public void AddBook(Book book) {  books.Add(book); }
        public void RemoveBook(Book book) {
            if (book == null)
                throw new ArgumentNullException(nameof(book), "Book cannot be null.");
            books.Remove(book); 

        }
        public ObservableCollection<Book> GetBooks() {return books;}
        public void UpdateBook(int bookId, Book updatedBook)
        {
            var book = books.FirstOrDefault(b => b.Id == bookId);
            if (book == null)
            {
              throw new ArgumentException($"Book with ID {bookId} not found."); 
            }
            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
        }



    }
}
