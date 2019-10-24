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
      double total = 0, lowGrade = this.Grades.ElementAt(0), highGrade = this.Grades.ElementAt(0);

      this.Grades.ForEach(grade =>
      {
        if (grade < lowGrade)
        {
          lowGrade = grade;
        }
        else if (grade > highGrade)
        {
          highGrade = grade;
        }

        total += grade;
      });

      return new Statistics
      {
        Average = total / this.Grades.Count,
        High = highGrade,
        Low = lowGrade
      };
    }
  }
}