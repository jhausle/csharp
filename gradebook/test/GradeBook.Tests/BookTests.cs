using Xunit;
//using System;

namespace GradeBook.Tests;

public class BookTests
{
  // Fact is an attribute
  // a piece of data that is attached to the method that follows it (Test1)
  [Fact]
  public void BookCalcsAverageGrade()
  {
    // Arrange - put together all the data
    var book = new InMemoryBook("");
    book.AddGrade(89.1);
    book.AddGrade(90.5);
    book.AddGrade(77.3);

    // Act - do some calculations that produce a result
    var result = book.GetStatistics();

    // Assert - check the results
    Assert.Equal(85.6, result.Average, 1);
    Assert.Equal(90.5, result.High, 1);
    Assert.Equal(77.3, result.Low, 1);
    Assert.Equal('B', result.Letter);

  }
}