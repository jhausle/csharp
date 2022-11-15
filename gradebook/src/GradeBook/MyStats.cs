using System;

namespace GradeBook
{
  public class MyStats
  {
    public MyStats()
    {
      Average = 0.0;
      Sum = 0.0;
      Count = 0;
      High = double.MinValue;
      Low = double.MaxValue;
    }
    public double Average;
    public double High;
    public double Low;
    public char Letter;
    public int Count;
    public double Sum;

    public void updateGrade(double grade)
    {
      High = Math.Max(High, grade);
      Low = Math.Min(Low, grade);
      Sum += grade;
      Average = Sum / ++Count;

      switch (Average)
      {
        case var d when d >= 90.0:
          Letter = 'A'; break;
        case var d when d >= 80.0:
          Letter = 'B'; break;
        case var d when d >= 70.0:
          Letter = 'C'; break;
        case var d when d >= 60.0:
          Letter = 'D'; break;
        default:
          Letter = 'F'; break;
      }
    }
  }
}