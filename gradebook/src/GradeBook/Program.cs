using System;
using System.Collections.Generic;

// electronic gradebook to read scores of inidividual student and then compute some statistics from the scores
// grades are entered as floats from 0-100 and stats should show us the highest, lowest, and average grade

// Static members are no associataed with object instances
// They are associated with the class type

namespace GradeBook
{
  class Program
  {
    static void Main(string[] args)
    {
      var book = new Book("John's Grade Book");
      book.AddGrade(89.1);
      book.AddGrade(90.5);
      book.AddGrade(77.5);

      var result = book.GetStatistics();

      Console.WriteLine($"Average of grades: {result.Average}");
      Console.WriteLine($"Max of grades: {result.High}");
      Console.WriteLine($"Min of grades: {result.Low}");
      Console.WriteLine($"Letter grade is: {result.Letter}");

    }
  }
}
