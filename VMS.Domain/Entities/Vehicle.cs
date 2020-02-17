using System;
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
    int Id;

    int speed;
    double latitude;
    double longitude;
    float temperature;
    float pressure;
    public DateTime Utc { get; set; }
    [MaxLength]
    string drivermessage;
  }
}
