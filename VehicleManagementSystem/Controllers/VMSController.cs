using System.Threading.Tasks;
using VMS.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace VMS.Controllers
{
 
    [Route("api/vehiclemanagement")]
    [ApiController]
    public class VMSController : Controller
    {
      private readonly IVMSService vehicleManagementService;

      public VMSController(IVMSService vehicleManagementService)
      {
        this.vehicleManagementService = vehicleManagementService;
      }

      [HttpGet]
      [Route("")]
      public IActionResult GetVehiclesList()
      {
        var vehicles = vehicleManagementService.GetVehiclesList();

        return Ok(vehicles);
      }


    [HttpGet]
    [Route("{id}")]
    public IActionResult Get(Guid id)
    {
      var vehicle = vehicleManagementService.GetVehicleById(id);

      if (vehicle == null)
      {
        return NotFound();
      }

      return Ok(vehicle);
    }

    [HttpPost]
      [Route("")]
      public IActionResult CreateVehicle([FromBody] VehicleModel model)
      {
      var vehicle = vehicleManagementService.CreateVehicle(model);

      return Ok(new { vehicle.Id });
    }
    [HttpPut]
    [Route("{id}")]
    public IActionResult Put([FromBody] VehicleModel model)
    {
     var vehicle= vehicleManagementService.UpdateVehicle(model);

      if (vehicle == null)
      {
        return NotFound();
      }

      return Ok(new { vehicle.Id });
    }


    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteVehicle(Guid id)
      {
        vehicleManagementService.DeleteVehicle(id);

        return Ok();
      }

    }
  }
