using System.Collections.Generic;
using System;
using System.IO;

namespace GradeBook
{
  // most delegates in C# have the following parameters
  public delegate void GradeAddedDelegate(object sender, EventArgs args);

  // All classes automatically derive from the base Object
  // object == system.Object
  public class NamedObject
  {
    public NamedObject(string name)
    {
      Name = name;
    }
    public string Name
    {
      get;
      set;
    }
  }

  // Interface should start with I
  // interfaces are much more common than abstract classes
  public interface IBook
  {
    void AddGrade(double grade);
    MyStats GetStatistics();
    string Name { get; }
    event GradeAddedDelegate GradeAdded;
  }

  public abstract class Book : NamedObject, IBook
  {
    public Book(string name) : base(name) { }
    public abstract event GradeAddedDelegate GradeAdded;
    public abstract void AddGrade(double grade);
    public abstract MyStats GetStatistics();
  }

  public class DiskBook : Book
  {
    public DiskBook(string name) : base(name)
    {
      // grades = some location?
    }
    public override event GradeAddedDelegate GradeAdded;
    public override MyStats GetStatistics()
    {
      var results = new MyStats();
      string line;
      using (var sw = File.OpenText($"{Name}.txt"))
      {
        line = sw.ReadLine();
        while (line != null)
        {
          results.updateGrade(double.Parse(line));
          line = sw.ReadLine();
        }

      }

      return results;
    }

    public override void AddGrade(double grade)
    {
      //string file = this.Name + ".txt";
      //StreamWriter sw = File.AppendText(file);
      using (StreamWriter sw = File.AppendText($"{Name}.txt"))
      {
        sw.WriteLine(grade);
        if (GradeAdded != null)
        {
          GradeAdded(this, new EventArgs());
        }
      }
      //sw.Dispose();
    }

  }

  // Book is a namedObject
  // Book inherists from the base class namedObject
  // Can only inherit from one
  // But can implement multiple interfaces
  public class InMemoryBook : Book
  {
    // below accesses the constructor of the base class. so calls constructor of namedObject
    // this is called chaining constructors
    public InMemoryBook(string name) : base(name)
    {
      grades = new List<double>();
      Name = name;
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

    // Can only override abstract/virtual methods
    public override void AddGrade(double grade)
    {
      if (grade <= 100 && grade >= 0.0)
      {
        grades.Add(grade);
        if (GradeAdded != null)
        {
          GradeAdded(this, new EventArgs());
        }
      }
      else
      {
        throw new ArgumentException($"Invalid {nameof(grade)}");
      }
    }

    // public GradeAddedDelegate GradeAdded;
    // Every book object has a gradeadded event
    public override event GradeAddedDelegate GradeAdded;

    public override MyStats GetStatistics()
    {
      var results = new MyStats();
      // var keyword uses implicit typing where the compiler figures out the appropriate type
      foreach (var number in grades)
      {
        results.updateGrade(number);
      }
      return results;
    }

    // This is considered a field of a class
    private List<double> grades;
    /*public string Name // This is an auto property
    {
      get;
      set; // Makes this a public get but a private set. effectively read only
    }*/

    //readonly string category = "Science"; // Can only initialize or modify in constructor
    public const string NEWCAT = "cat"; // Cannot be updated from constructor. Const values often all uppercase
                                        // This must be accessed by Book.NEWCAT now through an instantied variable/object book.NEWCAT
  }
}