namespace GradeBook
{
  public class Statistics
  {
    public double Average { get; set; }
    public double High { get; set; }
    public double Low { get; set; }

    public override string ToString()
    {
      return $"Average: {this.Average.ToString("0.##")}\n"
      + $"High: {this.High}\n"
      + $"Low: {this.Low}\n";
    }
  }
}