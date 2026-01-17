namespace MapApp.Api.Models
{
    public class MapData
    {
        public List<Polygon> Polygons { get; set; } = new();
        public List<MapObject> Objects { get; set; } = new();
    }
}
