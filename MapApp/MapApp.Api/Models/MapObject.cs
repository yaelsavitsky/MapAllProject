namespace MapApp.Api.Models
{
    public class MapObject
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Type { get; set; } = "Marker";
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
