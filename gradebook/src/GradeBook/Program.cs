using System;

namespace GradeBook
{
  class Program
  {
    static void Main(string[] args)
    {
      Book book = new Book("Midterm 1");
      book.AddGrade(20);
      book.AddGrade(90);
      book.AddGrade(80);

      var results = book.GetStats();

      System.Console.WriteLine(results);
    }
  }
}
