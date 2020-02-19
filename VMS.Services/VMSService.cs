using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VMS.Domain;
using VMS.Infrastructure.Extensions;
using Microsoft.Extensions.Options;
using System.Linq;
using VMS.Domain.Entities;

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

    public VehicleModel[] GetVehiclesList()
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

    public VehicleModel GetVehicleById(Guid id)
    {
      return context.vehicles.Where(vehicle => vehicle.Id == id).Select(vehicle => new VehicleModel
      {
        Id = vehicle.Id,
        Name = vehicle.Name,
        speed = vehicle.speed,
        latitude = vehicle.latitude,
        longitude = vehicle.longitude,
        temperature = vehicle.temperature,
        pressure = vehicle.pressure,
        drivermessage = vehicle.drivermessage
    }).SingleOrDefault();
    }
    public Vehicle CreateVehicle(VehicleModel model)
    {
      var newVehicle = new Vehicle
      {
        Name = model.Name,
      speed = model.speed,
      temperature = model.temperature,
      pressure = model.pressure,
      latitude = model.latitude,
      longitude = model.longitude,
      drivermessage = model.drivermessage
    };

      context.vehicles.Add(newVehicle);
      context.SaveChanges();

      return newVehicle;
    }

    public void DeleteVehicle(Guid id)
    { 
      var vehicle = context.vehicles.Find(id);

      context.vehicles.Remove(vehicle);
      context.SaveChanges();
    }

 
    public Vehicle UpdateVehicle(VehicleModel model)
    {
      var updatedVehicle = context.vehicles.SingleOrDefault(s => s.Id == model.Id);

      if (updatedVehicle == null)
      {
        return null;
      }

      //TODO: Input validation. Datatype validation is in place in Front end.

      updatedVehicle.Name = model.Name;
      updatedVehicle.speed = model.speed;
      updatedVehicle.temperature = model.temperature;
      updatedVehicle.pressure = model.pressure;
      updatedVehicle.latitude = model.latitude;
      updatedVehicle.longitude = model.longitude;
      updatedVehicle.drivermessage = model.drivermessage;

        context.vehicles.Add(updatedVehicle);
   
      context.SaveChanges();

      return updatedVehicle;
    }

  
  }
}
