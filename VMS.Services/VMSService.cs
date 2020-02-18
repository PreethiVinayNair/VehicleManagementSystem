using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VMS.Domain;
using VMS.Infrastructure.Extensions;
using Microsoft.Extensions.Options;

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

    public Task<object> createVehicleAsync(IDictionary<string, StringValues> vehicleArguments)
    {
      throw new NotImplementedException();
    }

    public Task CreateVehicleAsync(VehicleModel model)
    {
      throw new NotImplementedException();
    }

    public Task DeleteVehicleAsync(string vehicleName)
    {
      throw new NotImplementedException();
    }

    public Task<object> GetVehiclesAsync()
    {
      throw new NotImplementedException();
    }

    public Task<object> VehicleFieldsAsync(string vehicleName)
    {
      throw new NotImplementedException();
    }
  }
}
