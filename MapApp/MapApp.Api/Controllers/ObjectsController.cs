using MapApp.Api.Models;
using MapApp.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace MapApp.Api.Controllers
{

    [ApiController]
    [Route("api/objects")]
    public class ObjectsController : ControllerBase
    {
        private readonly JsonMapService _service;

        public ObjectsController(JsonMapService service)
        {
            _service = service;
        }

        // GET /api/objects
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var objects = await _service.GetObjectsAsync();
            return Ok(objects);
        }

        // POST /api/objects
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] List<MapObject> lstObjects)
        {
            await _service.SaveObjectsAsync(lstObjects);
            return Ok(await _service.GetObjectsAsync());
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObject(Guid id)
        {
            await _service.DeleteObjectAsync(id);

            return Ok(await _service.GetObjectsAsync());
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllObject()
        {
            await _service.DeleteAllObjectsAsync();
            return Ok(await _service.GetPolygonsAsync());
        }

    }
}
