using System;
using Xunit;
using Xunit.Abstractions;

namespace GradeBook.Tests
{


  public class BookTests
  {
    private readonly ITestOutputHelper output;

    public BookTests(ITestOutputHelper output)
    {
      this.output = output;
    }

    [Fact]
    public void Test1()
    {
      // arrange
      var book = new Book("unit_test");
      book.AddGrade(80.5);
      book.AddGrade(90.5);

      var res = book.GetStats();
    }
  }
}
