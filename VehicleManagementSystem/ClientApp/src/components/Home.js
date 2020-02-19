import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
        <div>
          <h1>Vehicle Management System</h1>
        <p>A prototype is required for you to show your abilities with the most used technologies at Coretex. </p>
        <p>  The challenge is to design a Vehicle Management System that allows the user to create, update and delete vehicles from it.
The system must at least have one vehicle entity that stores the vehicle data. The vehicle entity could have fields like:
- Vehicle Speed, latitude and longitude.
- Measurements from other device sensors in the vehicle like temperature, pressure etc.
- Vehicle driver’s messages.
</p>
        </div>

        );
      }
    }
