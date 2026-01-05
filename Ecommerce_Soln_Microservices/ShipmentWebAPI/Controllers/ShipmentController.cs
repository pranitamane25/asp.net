using Microsoft.AspNetCore.Mvc;
using ShipmentWebAPI.Models;
using ShipmentWebAPI.Services;

namespace ShipmentWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShipmentController : ControllerBase
{
    private readonly IShipmentService _service;

    public ShipmentController(IShipmentService service)
    {
        _service = service;
    }

    // GET: api/CreateShipment
    [HttpPost]
    public ActionResult CreateShipment([FromBody] Shipment shipment)
    {
        _service.CreateShipment(shipment);
        return Ok();
    }

    // GET: api/shipment
    [HttpGet]
    public ActionResult<IEnumerable<Shipment>> GetAll()
    {
        var shipments = _service.GetAllShipments();
        return Ok(shipments); // returns JSON automatically
    }

    // GET: api/shipment/5
    [HttpGet("{id:int}")]
    public ActionResult<Shipment> GetShipment(int id)
    {
        var shipment = _service.GetShipment(id);

        if (shipment == null)
            return NotFound($"Shipment with id {id} not found");

        return Ok(shipment);
    }

    // PUT: api/shipment/5/status
    [HttpPut("{id:int}/status")]
    public IActionResult UpdateStatus(int id, [FromBody] string status)
    {
        var shipment = _service.GetShipment(id);
        if (shipment == null)
            return NotFound($"Shipment with id {id} not found");

        _service.UpdateStatus(id, status);
        return NoContent(); // 204
    }

    // DELETE: api/shipment/5
    [HttpDelete("{id:int}")]
    public IActionResult CancelShipment(int id)
    {
        var shipment = _service.GetShipment(id);
        if (shipment == null)
            return NotFound($"Shipment with id {id} not found");

        _service.CancelShipment(id);
        return NoContent(); // 204
    }
}
