using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VMS.Domain;
using VMS.Infrastructure.Extensions;
using Microsoft.Extensions.Options;
using System.Linq;

namespace VMS.Services
{
  public class VMSService : IVMSService
  {
    private readonly ApplicationDbContext context;
    private readonly AppSettings appSettings;

    public VMSService(ApplicationDbContext context, IOptions<AppSettings> appSettings)
    {
      this.context = context;
      this.appSettings = appSettings.Value;
    }

    public Task<object> createVehicle(IDictionary<string, StringValues> vehicleArguments)
    {
      throw new NotImplementedException();
    }

    public VehicleModel[] ListVehicles()
    {
      return context.vehicles.Select(vehicle => new VehicleModel
      {
        Id = vehicle.Id,
        Name = vehicle.Name,
        speed = vehicle.speed,
        latitude = vehicle.latitude,
        longitude = vehicle.longitude,
        temperature = vehicle.temperature,
        pressure = vehicle.pressure,
        drivermessage = vehicle.drivermessage
      }).ToArray();
    }
    public Task CreateVehicle(VehicleModel model)
    {
      return null;
    }

    public void DeleteVehicle(string vehicleName)
    {
      var vehicle = context.vehicles.Find(vehicleName);

      context.vehicles.Remove(vehicle);
      context.SaveChanges();
    }

    public Task<object> GetVehicles()
    {
      throw new NotImplementedException();
    }

    public Task<object> VehicleFields(string vehicleName)
    {
      throw new NotImplementedException();
    }

  }
}
