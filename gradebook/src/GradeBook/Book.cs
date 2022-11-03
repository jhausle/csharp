using System.Collections.Generic;
using System;

namespace GradeBook
{
  public class Book
  {
    public Book(string name)
    {
      grades = new List<double>();
      this.Name = name;
    }
    public void AddGrade(char letter)
    {
      switch (letter)
      {
        case 'A':
          AddGrade(90);
          break;
        case 'B':
          AddGrade(80);
          break;
        case 'C':
          AddGrade(70);
          break;
        case 'D':
          AddGrade(60);
          break;
        case 'F':
          AddGrade(50);
          break;
        default: AddGrade(0); break;
      }
    }
    public void AddGrade(double grade)
    {
      if (grade <= 100 && grade >= 0.0)
        grades.Add(grade);
      else
      {
        throw new ArgumentException($"Invalid {nameof(grade)}");
      }
    }

    public MyStats GetStatistics()
    {
      // var keyword uses implicit typing where the compiler figures out the appropriate type
      var result = new MyStats();
      var sum = 0.0;
      result.High = double.MinValue;
      result.Low = double.MaxValue;

      foreach (var number in grades)
      {
        if (number == 42.1)
        {
          break;
        }
        result.High = Math.Max(result.High, number);
        result.Low = Math.Min(result.Low, number);
        sum += number;
      }
      result.Average = sum / grades.Count;

      switch (result.Average)
      {
        case var d when d >= 90.0:
          result.Letter = 'A'; break;
        case var d when d >= 80.0:
          result.Letter = 'B'; break;
        case var d when d >= 70.0:
          result.Letter = 'C'; break;
        case var d when d >= 60.0:
          result.Letter = 'D'; break;
        default:
          result.Letter = 'F'; break;
      }

      return result;
    }

    // This is considered a field of a class
    private List<double> grades;
    public string Name // This is an auto property
    {
      get;
      set; // Makes this a public get but a private set. effectively read only
    }

    //readonly string category = "Science"; // Can only initialize or modify in constructor
    public const string NEWCAT = "cat"; // Cannot be updated from constructor. Const values often all uppercase
    // This must be accessed by Book.NEWCAT now through an instantied variable/object book.NEWCAT
  }
}