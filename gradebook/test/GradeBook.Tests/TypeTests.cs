using Xunit;
//using System;

namespace GradeBook.Tests;

// If something is a class then it is a reference type
// A struct can be a value type
// STRING is a reference type
public struct Point
{
  int x;
  int y;
}

public delegate string WriteLogDelegate(string logMessage); // I think this is like a function pointer?
// multi-case delegates could be useful for having multiple callbacks to a single event

public class TypeTests
{
  int count = 0;
  [Fact]
  public void WriteLogDelegateCanPointToMethod()
  {
    WriteLogDelegate log = ReturnMessage;

    // This is the long hand
    // log = new WriteLogDelegate(ReturnMessage);
    log += IncrementCount;

    var result = log("Hello!");
    Assert.Equal("Hello!", result);
    Assert.Equal(2, count);

  }
  string IncrementCount(string message)
  {
    count++;
    return message;
  }
  string ReturnMessage(string message)
  {
    count++;
    return message;
  }
  [Fact]
  public void StringsBehaveLikeValueTypes()
  {
    string name = "Scott"; // name is a reference to the value "scott"
    var upper = MakeUpperCase(name);
    Assert.Equal("Scott", name);
    Assert.Equal("SCOTT", upper);
  }
  private string MakeUpperCase(string param)
  {
    return param.ToUpper();
  }
  [Fact]
  public void UpdateIntByRef()
  {
    var x = GetInt();
    SetInt(ref x);
    Assert.Equal(42, x);
  }

  private void SetInt(ref int x)
  {
    x = 42;
  }
  private int GetInt()
  {
    return 3;
  }
  // Fact is an attribute
  // a piece of data that is attached to the method that follows it (Test1)
  [Fact]
  public void GetBookReturnsDifferentObjects()
  {
    // Arrange - put together all the data
    var book1 = GetBook("Book 1");
    var book2 = GetBook("Book 2");

    Assert.Equal("Book 1", book1.Name);
    Assert.Equal("Book 2", book2.Name);
    Assert.NotSame(book1, book2);
  }

  [Fact]
  public void TwoVarsReferenceSameObject()
  {
    // Arrange - put together all the data
    var book1 = GetBook("Book 1");
    var book2 = book1;

    Assert.Same(book1, book2);
    Assert.True(object.ReferenceEquals(book1, book2));
  }

  [Fact]
  public void CanSetNameFromReference()
  {
    // Arrange - put together all the data
    var book1 = GetBook("Book 1"); // book1 is a reference to a Book Object
    SetName(book1, "New Name");

    Assert.Equal("New Name", book1.Name);
  }

  private void SetName(Book book, string name)
  {
    book.Name = name;
  }
  [Fact]
  public void CSharpIsPassByValue()
  {
    // Arrange - put together all the data
    var book1 = GetBook("Book 1"); // book1 is a reference to a Book Object
    GetBookSetName(book1, "New Name");

    Assert.Equal("Book 1", book1.Name);
  }

  private void GetBookSetName(Book book, string name)
  {
    book = new Book(name);
  }

  Book GetBook(string name)
  {
    return new Book(name); // new creates the object but returns a reference to the address of that object
  }


  [Fact]
  public void CSharpCanPassByRef()
  {
    // Arrange - put together all the data
    var book1 = GetBook("Book 1"); // book1 is a reference to a Book Object
    GetBookSetName(ref book1, "New Name");

    Assert.Equal("New Name", book1.Name);
  }

  // out and ref can be almost the same
  // out is slightly safer sometimes as c# assumes out params are uninitialized and the compiler forces it to be assigned within the method
  private void GetBookSetName(ref Book book, string name)
  {
    book = new Book(name);
  }
}