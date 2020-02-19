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
    Task CreateVehicle(VehicleModel model);
    void DeleteVehicle(string vehicleName);
    Task<object> GetVehicles();
    Task<object> VehicleFields(string vehicleName);
  }
}
