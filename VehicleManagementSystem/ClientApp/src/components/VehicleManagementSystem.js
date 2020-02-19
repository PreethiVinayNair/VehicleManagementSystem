import React, { Component } from 'react';
import AppActions from './../actions/AppActions';
import { get, post } from "../lib/http";


export class VehicleManagementSystem extends Component {
  static displayName = VehicleManagementSystem.name;
 
  constructor(props) {
    super(props);
    VehicleManagementSystem.update();
  }


  static update() {
    get('api/vehiclemanagement', (data) => AppActions.updateStates([
      { statePath: 'vehicles', data },
      { statePath: 'loading', data: false }
          ]));
  }

  renderVehiclesTable(history, vehicles) {
    return (
      <table className='table'>
        <thead>
          <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Speed</th>
            <th>Latitude</th>
            <th>Longitude</th>
            <th>Temperature</th>
            <th>Pressure</th>
            <th>DriverMessage</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {vehicles.map(v =>
            <tr key={v.id}>
              <td>{v.id}</td>
              <td>{v.name}</td>
              <td>{v.speed}</td>
              <td>{v.latitude}</td>
              <td>{v.longitude}</td>
              <td>{v.temperature}</td>
              <td>{v.pressure}</td>
              <td>{v.drivermessage}</td>
              <td><button onClick={() => history.push(`/vehiclemanager/${v.id}`)}>Edit</button></td>
            </tr>
          )}
        </tbody>
        <tfoot>
          <tr>
            <td colSpan="9"></td>
            <td><button onClick={() => history.push(`/vehiclemanager/_`)}>New</button></td>
          </tr>
        </tfoot>
      </table>
    );
  }



  render() {
    const { history, loading, vehicles,vehicle } = this.props;

    let contents = loading
      ? <p><em>Loading...</em></p>
      : this.renderVehiclesTable(history, vehicles);


    return (
      <div>
      <div>
        <h1>Vehicle Management System</h1>
        {contents}
      </div>
      </div>

    );
  }

}

VehicleManagementSystem.defaultProps = {
  loading: false,
  vehicles: []
  }