using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class WarehouseController: Controller
    {
        public WarehouseController()
        {
        }

        [HttpGet]
        public IActionResult GetWarehouse()
        {
            return Ok("Hello World!");
        }
    }
}
