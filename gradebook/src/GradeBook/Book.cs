using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
  public class Book
  {
    public string Name { get; set; }
    public List<double> Grades { get; set; }

    public Book(string Name)
    {
      this.Name = Name;
      this.Grades = new List<double>();
    }

    public void AddGrade(double grade)
    {
      this.Grades.Add(grade);
    }

    public Statistics GetStats()
    {
      var res = new Statistics();

      this.Grades.ForEach(grade =>
      {
        res.Low = Math.Min(grade, res.Low);
        res.High = Math.Max(grade, res.High);
        res.Average += grade;
      });

      res.Average /= this.Grades.Count;

      return res;
    }
  }
}