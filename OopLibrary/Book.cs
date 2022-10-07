using System.Reflection.PortableExecutable;
using System.Text;

namespace OopLibrary;

public class Book
{
    private int _totalNumberOfEx; // Hur många har vi totalt
    private int _borrowedCount; //Hur många är utlånade
    private string _title;


    public string Title
    {
        get { return _title; }
    }
    public int BorrowedCount
    {
        get { return _borrowedCount; }
    }
    public int Count
    {
        get { return _totalNumberOfEx; }
    }
    public void AddCount(int count)
    {
        _totalNumberOfEx += count;
    }

    public Book(string title)
    {
        _title = title;
        _totalNumberOfEx = 0;
        _borrowedCount = 0;
    }


    public bool TryBorrow()
    {
        if (_borrowedCount >= _totalNumberOfEx) return false;
        _borrowedCount++;
        return true;
    }

    public void Return()
    {
        if (_borrowedCount > 0)
            _borrowedCount--;
    }
}