﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMS.Domain.Entities
{
 public class Vehicle
  {
    // Vehicle Speed, latitude and longitude.
    //Measurements from other device sensors in the vehicle like temperature, pressure etc.
    //Vehicle driver’s messages
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int speed { get; set; }
    public string latitude { get; set; }
    public string longitude { get; set; }
    public float temperature { get; set; }
    public float pressure { get; set; }
    public DateTime Utc { get; set; } 

    [MaxLength]
    public string drivermessage { get; set; }

  }
}
