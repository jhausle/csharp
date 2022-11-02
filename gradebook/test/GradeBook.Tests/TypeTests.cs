using Xunit;
//using System;

namespace GradeBook.Tests;

public class TypeTests
{
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

    // Act - do some calculations that produce a result

    // Assert - check the results

  }

  Book GetBook(string name)
  {
    return new Book(name);
  }
}