using System;
using Xunit;
namespace Gradebook.Tests;

public class TypeTests
{

    public delegate string WriteLogDelegate(string logMessage); //Func<string,string>
                                                                //Need to be string about return types
    int count  = 0;

    [Fact]
    public void WriteLogDelegateCanPointToMethod()
    {
        WriteLogDelegate log = ReturnMessage;
        log += ReturnMessage; //new WriteLogDelegate(ReturnMessage)
        log += IncrementCount;

        var result = log("Hello!");
        Assert.Equal("Hello!", result);
        Assert.Equal(3, count);

    }

    string IncrementCount(string message)
    {
        count ++;
        return message;
    }

    string ReturnMessage(string message)
    {
        count ++;
        return message;
    }



    [Fact]
    public void GradeRangeValidation()
    {
        var book1 = new Book("Book 1");
        var OutOfRangeGrade = 105.0;

        book1.AddGrade(OutOfRangeGrade);
        Assert.DoesNotContain(OutOfRangeGrade, book1.GetGrades());
    }

    [Fact]
    public void StringsBehaveLikeValueTypes()
    {
        string name = "Connor";
        string upper = MakeUppercase(name);

        Assert.Equal("Connor", name);
        Assert.Equal("CONNOR", upper);

    }

    private string MakeUppercase(string parameter)
    {
        return parameter.ToUpper();
    }

    [Fact]
    public void ValueTypesAlsoPassByValue()
    {
        int x = GetInt();
        SetInt(ref x);

        Assert.Equal(42, x);
    }
    private int GetInt()
    {
        return 3;
    }
    private void SetInt(ref int z)
    {
        z = 42;
    }

    [Fact]
    public void CSharpCanPassByRef()
    {
        var book1 = GetBook("Book 1");
        GetBookSetName(ref book1, "New Name");
        Assert.Equal("New Name", book1.Name);
    }
    private void GetBookSetName(ref Book book, string name)
        {
           book = new Book(name);
        }

    [Fact]
    public void CSharpIsPassByValue()
    {
        // arrange section
        var book1 = GetBook("Book 1");
        GetBookSetName(book1, "New Name");

        Assert.Equal("Book 1", book1.Name);
    }
    private void GetBookSetName(Book book, string name)
        {
           book = new Book(name);
        }

    [Fact]
    public void CanSetNameFromReference()
    {
        // arrange section
        var book1 = GetBook("Book 1");
        SetName(book1, "New Name");

        Assert.Equal("New Name", book1.Name);
    }
    private void SetName(Book book, string name)
        {
            book.Name = name;
        }

    [Fact]
    public void GetBookReturnsDifferentObjects()
    {
        // arrange section
        var book1 = GetBook("Book 1");
        var book2 = GetBook("Book 2");

        Assert.Equal("Book 1", book1.Name);
        Assert.Equal("Book 2",book2.Name);
        Assert.NotSame(book1, book2);
        
    }

    [Fact]
    public void TwoVariablesCanReferenceSameObject()
    {
        // arrange section
        var book1 = GetBook("Book 1");
        var book2 = book1;

        Assert.Same(book1, book2);
        Assert.True(Object.ReferenceEquals(book1, book2));
    }
    Book GetBook(string name)
    {
        return new Book(name);

    }
}

   
