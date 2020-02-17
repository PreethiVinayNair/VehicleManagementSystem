
using System;
using System.Collections.Generic;
using System.Text;

namespace VMS.Domain.Entities
{
  class Vehicle
  {
    // Vehicle Speed, latitude and longitude.
    //Measurements from other device sensors in the vehicle like temperature, pressure etc.
    //Vehicle driver’s messages

    int speed;
    double latitude;
    double longitude;
    float temperature;
    float pressure;
    string drivermessage;
  }
}
