using System;
using System.Collections.Generic;
using System.Text;

namespace VMS.Services
{
  public class VehicleModel
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int speed { get; set; }
    public double latitude { get; set; }
    public double longitude { get; set; }
    public float temperature { get; set; }
    public float pressure { get; set; }
    public DateTime Utc { get; set; }
    public string drivermessage { get; set; }
  }
}

