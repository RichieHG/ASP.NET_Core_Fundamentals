using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WarehouseController : Controller
    {
        private readonly IWarehouseService _warehouseService;
        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        // /api/warehouse
        [HttpGet]
        public IActionResult GetWarehouses()
        {
            return Ok(_warehouseService.GetWarehouses());
        }

        // /api/warehouse/byWarehouseId?warehouseId=3&warehouseName=Ricardo
        [HttpGet("byWarehouseId")]
        public IActionResult GetWarehouseFromQuery([FromQuery] int warehouseId, [FromQuery] string warehouseName)
        {
            return Ok($"Hello {warehouseName}! You user is {warehouseId}");
        }

        // /api/warehouse/3
        [HttpGet("{warehouseid}/name/{warehouseName}")]
        public IActionResult GetWarehouseFromRoute([FromRoute] int warehouseId, [FromRoute] string warehouseName)
        {
            return Ok($"Hello {warehouseName}! You user is {warehouseId}");
        }

        // /api/warehouse
        [HttpPost]
        public IActionResult CreateWarehouse([FromBody] WarehouseDTO newWarehouse, [FromServices] IWarehouseService _service)
        {
            if (_service.CreateWarehouse())
                return Ok($"Warehouse Created\nId: {newWarehouse.WarehouseId} | Name: {newWarehouse.Name}");
            else return BadRequest("Warehouse was not created");
        }

    }
}
