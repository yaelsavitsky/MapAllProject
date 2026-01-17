namespace MapApp.Api.Models
{
    public class Point
    {
        public double? lat { get; set; }
        public double? lng { get; set; }
    }

    public class Polygon
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public List<Point> points { get; set; }

    }
}
