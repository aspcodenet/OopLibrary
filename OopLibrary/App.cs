using System.Security.Cryptography.X509Certificates;

namespace OopLibrary;

public class App
{
    public int Meny()
    {
        while (true)
        {
            Console.WriteLine("1. Köp in bok");
            Console.WriteLine("2. Ny utlåning");
            Console.WriteLine("3. Ny tillbakalämning");
            Console.Write(":");
            var sel = Convert.ToInt32(Console.ReadLine());
            if (sel > 0 && sel < 4) return sel;
            Console.WriteLine("Felaktigt val!");
        }
    }

    public void AddBook(Library library)
    {
        Console.Write("Titel");
        var title = Console.ReadLine();
        Console.Write("Hur många exemplar har ni köpt in:");
        var antal = Convert.ToInt32( Console.ReadLine());
        library.AddBookToLibrary(title,antal);

        var book = library.FindBook(title);
        Console.WriteLine($"Nu har vi {book.Count} exemplar av {book.Title} varav {book.BorrowedCount} är utlånade");
    }

    public void BorrowBook(Library library)
    {
        Console.Write("Titel");
        var title = Console.ReadLine();
        var book = library.FindBook(title);
        if(book == null)
            Console.WriteLine("Den boken har vi inte alls!");
        else
        {
            if (book.TryBorrow() == false)
            {
                Console.WriteLine("Sorry, alla ex är redan utlånade!!");
            }
            else
            {
                Console.WriteLine("Ok utlånad. Se till att du lämnar tillbaka i tid!");
            }
        }

       
    }

    public void ReturnBook(Library library)
    {
        Console.Write("Titel");
        var title = Console.ReadLine();
        var book = library.FindBook(title);
        if (book == null)
            Console.WriteLine("Den boken har vi inte alls!");
        else
        {
            book.Return();
            Console.WriteLine("Boken återlämnad");
        }


    }

    public void Run()
    {
        var library = new Library();

        //Biblioteket köper in 3 ex av denna
        library.AddBookToLibrary("C# for Dummies",3);

        library.AddBookToLibrary("C# for Pros", 2);

        while (true)
        {
            var sel = Meny();
            if (sel == 1)
                AddBook(library);
            else if (sel == 2)
                BorrowBook(library);
            else if (sel == 3)
                ReturnBook(library);
        }
    }
}