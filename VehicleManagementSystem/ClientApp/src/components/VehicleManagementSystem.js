import React, { Component } from 'react';
import AppActions from './../actions/AppActions';
import { Button, ControlLabel, Form, FormControl, FormGroup, Col } from "react-bootstrap";
import bindValueTo from "../lib/bindValueTo";
import { NotificationManager } from 'react-notifications';
import { get, post } from "../lib/http";

export class VehicleManagementSystem extends Component {
  static displayName = VehicleManagementSystem.name;

  constructor(props) {
    super(props);
    VehicleManagementSystem.update();
  }

  static update() {
    get('api/vehiclemanagement', (data) => AppActions.updateStates([
      { statePath: 'vehicles', data: data.value },
      { statePath: 'loading', data: false },
      {
        statePath: 'vehicle', data: {
          speed: '',
          latitude: '',
          longitude: '',
          temperature: '',
          pressure: '',
          drivermessage: ''
        }
      }
    ]));
  }

  renderVehiclesTable(history, vehicles) {
    return (
      <table className='table'>
        <thead>
          <tr>
            <th>Vehicle Added History</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {vehicles.map(i =>
            <tr key={i.name}>
              <td>{i.name}</td>
              <td>
                <button onClick={() => history.push(`/vehicles/${encodeURIComponent(i.name)}`)}>View</button>
              </td>
            </tr>
          )}
        </tbody>
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
        <h1>Vehicles</h1>
        {contents}

        {vehicle && <Form horizontal>
          <Form.Group controlId="Name">   
            <Form.Label>Name</Form.Label>
            <Col sm={10}>
              <Form.Control type="text" value={vehicle.name}
                onChange={bindValueTo('vehicle.name')} />
            </Col>
          </Form.Group>
          <Form.Group controlId="Speed">     
            <Form.Label>Speed</Form.Label>
            <Col sm={10}>
              <Form.Control type="text" value={vehicle.speed}
                onChange={bindValueTo('vehicle.speed')} />
            </Col>
          </Form.Group>
          <Form.Group controlId="latitude">
            <Form.Label>Latitude</Form.Label>
            <Col sm={10}>
              <Form.Control type="text" value={vehicle.latitude}
                onChange={bindValueTo('vehicle.latitude')} />
            </Col>
          </Form.Group>
          <Form.Group controlId="longitude">
            <Form.Label>Longitude</Form.Label>
            <Col sm={10}>
              <Form.Control type="text" value={vehicle.longitude}
                onChange={bindValueTo('vehicle.longitude')} />
            </Col>
          </Form.Group>
          <Form.Group controlId="temperature">
            <Form.Label>Temperature</Form.Label>
            <Col sm={10}>
              <Form.Control type="text" value={vehicle.temperature}
                onChange={bindValueTo('vehicle.temperature')} />
            </Col>
          </Form.Group>
          <Form.Group controlId="pressure">
            <Form.Label>pressure</Form.Label>
            <Col sm={10}>
              <Form.Control type="text" value={vehicle.pressure}
                onChange={bindValueTo('vehicle.pressure')} />
            </Col>
          </Form.Group>
          <Form.Group controlId="drivermessage">
            <Form.Label>Message to Driver</Form.Label>
            <Col sm={10}>
              <Form.Control type="text" value={vehicle.drivermessage}
                onChange={bindValueTo('vehicle.drivermessage')} />
            </Col>
          </Form.Group>

          <Button onClick={() => this.createVehicle()}>Create Vehicle Data</Button>
          <Button onClick={() => this.updateVehicle()}>Update Vehicle Data</Button>
          <Button onClick={() => this.deleteVehicle()}>Delete Vehicle Data</Button>
        </Form>}

      </div>
    );
  }
  createVehicle() {
    const { vehicle } = this.props;
    post('api/vehiclemanagement/createvehicleasync', vehicle, () => {
      NotificationManager.success('vehicle created');
      VehicleManagementSystem.update();
    });
  }

  updateVehicle() {
    const { vehicle } = this.props;
    post('api/vehiclemanagement/createvehicleasync', vehicle, () => {
      NotificationManager.success('vehicle created');
      VehicleManagementSystem.update();
    });
  }

  deleteVehicle() {
    const { vehicle } = this.props;
    post('api/vehiclemanagement/createvehicleasync', vehicle, () => {
      NotificationManager.success('vehicle created');
      VehicleManagementSystem.update();
    });
  }
}

VehicleManagementSystem.defaultProps = {
  loading: false,
  vehicles: [],
  vehicle: {
    name: '',
    speed: '',
    latitude: '',
    longitude: '',
    temperature: '',
    pressure: '',
    drivermessage: ''

  }
};