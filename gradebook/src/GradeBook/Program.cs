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
      //book.GradeAdded += OnGradeAdded; because its an EVENT, this is not possible. This is generally bad anyway b/c things can overwrite each other
      book.GradeAdded += OnGradeAdded;
      var done = false;
      while (!done)
      {
        Console.WriteLine("Enter a Grade or 'q' to quit:");
        var input = Console.ReadLine();
        if (input == "q")
        {
          done = true;
        }
        try
        {
          var grade = double.Parse(input);
          book.AddGrade(grade);
        }
        //catch (Exception ex) // Only catch exceptions you expect and know you want to handle
        catch (ArgumentException ex)
        {
          Console.WriteLine(ex.Message);
          //throw; This is what you would do if you wanted to re-throw the exception. Maybe you want another level to process it or just want the program to crash
        }
        catch (FormatException ex)
        {
          Console.WriteLine(ex.Message);
        }
        finally
        {
          // Allows you to ALWAYS execut this code regardless of success or exception
        }
      }

      var result = book.GetStatistics();

      Console.WriteLine($"For the book name: {book.Name}");
      Console.WriteLine($"Average of grades: {result.Average}");
      Console.WriteLine($"Max of grades: {result.High}");
      Console.WriteLine($"Min of grades: {result.Low}");
      Console.WriteLine($"Letter grade is: {result.Letter}");

    }
    static void OnGradeAdded(object sender, EventArgs e)
    {
      Console.WriteLine("Grade was Added!");

    }
  }
}
