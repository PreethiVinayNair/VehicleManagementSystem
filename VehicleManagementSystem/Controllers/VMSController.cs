using System.Threading.Tasks;
using VMS.Services;
using Microsoft.AspNetCore.Mvc;


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
      public async Task<IActionResult> Get()
      {
        var vehicles = await vehicleManagementService.GetVehicles();

        return Ok(vehicles);
      }


      [HttpGet]
      [Route("{vehicleName}")]
      public async Task<IActionResult> Get(string vehicleName)
      {
        var fields = await vehicleManagementService.VehicleFields(vehicleName);

        return Ok(fields);
      }


      [HttpPost]
      [Route("createVehicleAsync")]
      public async Task<IActionResult> CreateVehicle(VehicleModel model)
      {
        await vehicleManagementService.CreateVehicle(model);

        return Ok(new object { });
      }


      [HttpDelete]
      [Route("{vehicleName}")]
      public IActionResult Delete(string vehicleName)
      {
        vehicleManagementService.DeleteVehicle(vehicleName);

        return Ok();
      }

    }
  }
