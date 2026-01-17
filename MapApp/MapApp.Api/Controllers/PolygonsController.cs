using MapApp.Api.Models;
using MapApp.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace MapApp.Api.Controllers
{
    [ApiController]
    [Route("api/polygons")]
    public class PolygonsController : ControllerBase
    {
        private readonly JsonMapService _service;

        public PolygonsController(JsonMapService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Polygon> lstPolygons = await _service.GetPolygonsAsync();
            return Ok(lstPolygons);
        }

        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] Polygon polygon)
        //{
        //    await _service.AddPolygonAsync(polygon);
        //    return Ok(await _service.GetPolygonsAsync());
        //}

        [HttpPost]
        public async Task<IActionResult> AddPolygons([FromBody] List<Polygon> lstPolygons)
        {
            if (lstPolygons == null || lstPolygons.Count == 0)
                return BadRequest();

            await _service.AddPolygonsAsync(lstPolygons);
            return Ok(await _service.GetPolygonsAsync());
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolygon(Guid id)
        {
             await _service.DeletePolygonByIdAsync(id);

            return Ok(await _service.GetPolygonsAsync());
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllPolygons()
        {
            await _service.DeleteAllPolygonsAsync();
            return Ok(await _service.GetPolygonsAsync());
        }
    }
}
