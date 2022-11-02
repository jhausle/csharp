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
    public void AddGrade(double grade)
    {
      grades.Add(grade);
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
        result.High = Math.Max(result.High, number);
        result.Low = Math.Min(result.Low, number);
        sum += number;
      }
      result.Average = sum / grades.Count;
      return result;
    }

    // This is considered a field of a class
    private List<double> grades;
    public string Name; // public members should be captialized
  }
}