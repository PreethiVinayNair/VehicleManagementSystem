using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;

namespace VMS.Services
{
  public interface IVMSService
  {

    Task<object> createVehicle(IDictionary<string, StringValues> vehicleArguments);
    Task CreateVehicleAsync(VehicleModel model);
    Task DeleteVehicleAsync(string vehicleName);
    Task<object> GetVehiclesAsync();
    Task<object> VehicleFieldsAsync(string vehicleName);
  }
}
