using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VMS.Services
{
  public class VMSService : IVMSService
  {
    public Task<object> createVehicle(IDictionary<string, StringValues> vehicleArguments)
    {
      throw new NotImplementedException();
    }
  }
}
