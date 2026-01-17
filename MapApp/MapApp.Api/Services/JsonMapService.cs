using MapApp.Api.Models;
using System.Text.Json;

namespace MapApp.Api.Services
{

    public class JsonMapService
    {
        private readonly string _filePath = "Data/MapData.json";

        private async Task<MapData> ReadAsync()
        {
            var json = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<MapData>(json)!;
        }

        private async Task WriteAsync(MapData data)
        {
            var json = JsonSerializer.Serialize(
                data,
                new JsonSerializerOptions { WriteIndented = true }
            );

            await File.WriteAllTextAsync(_filePath, json);
        }

        // Polygons

        public async Task<List<Polygon>> GetPolygonsAsync()  => (await ReadAsync()).Polygons;


        public async Task AddPolygonsAsync(List<Polygon> newLstPolygons)
        {
            var data = await ReadAsync();
            data.Polygons.AddRange(newLstPolygons);
            await WriteAsync(data);
        }
        public async Task AddPolygonAsync(Polygon polygon)
        {
            var data = await ReadAsync();
            data.Polygons.Add(polygon);
            await WriteAsync(data);
        }

        public async Task DeleteAllPolygonsAsync()
        {
            var data = await ReadAsync();
            data.Polygons.Clear();
            await WriteAsync(data);
        }

        public async Task DeletePolygonByIdAsync(Guid id)
        {
            var data = await ReadAsync();
            var polygon = data.Polygons.FirstOrDefault(p => p.Id == id);

            if(polygon != null)
            {
                data.Polygons.Remove(polygon);
            }

            await WriteAsync(data);
        }

    

        // Objects

        public async Task<List<MapObject>> GetObjectsAsync()  => (await ReadAsync()).Objects;

        public async Task SaveObjectsAsync(List<MapObject> lstObjects)
        {
            var data = await ReadAsync();
            data.Objects.AddRange(lstObjects);
            await WriteAsync(data);
        }

        public async Task DeleteObjectAsync(Guid id)
        {
            var data = await ReadAsync();
            data.Objects.RemoveAll(o => o.Id == id);
            await WriteAsync(data);
        }


        public async Task DeleteAllObjectsAsync()
        {
            var data = await ReadAsync();
            data.Objects.Clear();
            await WriteAsync(data);
        }

    }
}
