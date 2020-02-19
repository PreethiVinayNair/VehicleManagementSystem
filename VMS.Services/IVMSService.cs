using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using VMS.Domain.Entities;

namespace VMS.Services
{
  public interface IVMSService
  {

    Task<object> createVehicle(IDictionary<string, StringValues> vehicleArguments);
    Vehicle CreateVehicle(VehicleModel model);
    Vehicle UpdateVehicle(VehicleModel model);
    void DeleteVehicle(Guid id);
    VehicleModel[] GetVehiclesList();
    VehicleModel GetVehicleById(Guid id);
  }
}
