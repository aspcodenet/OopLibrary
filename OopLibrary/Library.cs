using System.Reflection;

namespace OopLibrary;

public class Library
{
    private List<Book> books = new List<Book>();

    public void AddBookToLibrary(string title, int count)
    {
        var book = FindBook(title);
        if (book == null)
        {
            book = new Book(title);
            books.Add(book);
        }

        book.AddCount(count);
    }

    public Book FindBook(string title)
    {
        foreach(var book in books)
            if (book.Title == title)
                return book;
        return null;
    }
}