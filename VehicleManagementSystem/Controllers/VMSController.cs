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
        var vehicles = await vehicleManagementService.GetVehiclesAsync();

        return Ok(vehicles);
      }


      [HttpGet]
      [Route("{vehicleName}")]
      public async Task<IActionResult> Get(string vehicleName)
      {
        var fields = await vehicleManagementService.VehicleFieldsAsync(vehicleName);

        return Ok(fields);
      }


      [HttpPost]
      [Route("createVehicleAsync")]
      public async Task<IActionResult> CreateVehicleAsync(VehicleModel model)
      {
        await vehicleManagementService.CreateVehicleAsync(model);

        return Ok(new object { });
      }


      [HttpDelete]
      [Route("{indexerName}")]
      public async Task<IActionResult> Delete(string vehicleName)
      {
        await vehicleManagementService.DeleteVehicleAsync(vehicleName);

        return Ok();
      }

    }
  }
