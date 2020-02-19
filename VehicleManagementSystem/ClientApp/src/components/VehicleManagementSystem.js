import React, { Component } from 'react';
import AppActions from './../actions/AppActions';
import { Button,  Form, FormGroup,ControlLabel,FormControl,  Col } from "react-bootstrap";
import bindValueTo from "../lib/bindValueTo";
import { NotificationManager } from 'react-notifications';
import { get, post } from "../lib/http";

export class VehicleManagementSystem extends Component {
  static displayName = VehicleManagementSystem.name;

  constructor(props) {
    super(props);
    VehicleManagementSystem.update();
    this.handleChange = this.handleChange.bind(this);
  }
  handleChange = e => {
    this.setState({ [e.target.name]: e.target.value });
  };


  static update() {
    get('api/vehiclemanagement', (data) => AppActions.updateStates([
      { statePath: 'vehicles', data: data.value },
      { statePath: 'loading', data: false },
      {
        statePath: 'vehicle', data: {
          name: '',
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
          <FormGroup controlId="Name">
            <Col componentClass={ControlLabel} sm={2}>
              Name
                        </Col>
            <Col sm={10}>
              <FormControl type="text" onChange={bindValueTo('vehicle.name')} />
            </Col>
          </FormGroup>
          <FormGroup controlId="Speed">
            <Col componentClass={ControlLabel} sm={2}>
              Speed
                        </Col>
            <Col sm={10}>
              <FormControl type="number"
                onChange={bindValueTo('vehicle.speed')} />
            </Col>
          </FormGroup>
          <FormGroup controlId="Latitude">
            <Col componentClass={ControlLabel} sm={2}>
              Latitude
                        </Col>
            <Col sm={10}>
              <FormControl type="number" 
                onChange={bindValueTo('vehicle.latitude')} />
            </Col>
          </FormGroup>
          <FormGroup controlId="Longitude">
            <Col componentClass={ControlLabel} sm={2}>
              Longitude
                        </Col>
            <Col sm={10}>
              <FormControl type="number" 
                onChange={bindValueTo('vehicle.longitude')} />
            </Col>
          </FormGroup>
          <FormGroup controlId="Temperature">
            <Col componentClass={ControlLabel} sm={2}>
              Temperature
                        </Col>
            <Col sm={10}>
              <FormControl type="number" 
                onChange={bindValueTo('vehicle.temperature')} />
            </Col>
          </FormGroup>
          <FormGroup controlId="Pressure">
            <Col componentClass={ControlLabel} sm={2}>
              Pressure
                        </Col>
            <Col sm={10}>
              <FormControl type="number" 
                onChange={bindValueTo('vehicle.pressure')} />
            </Col>
          </FormGroup>
          <FormGroup controlId="DriverMessage">
            <Col componentClass={ControlLabel} sm={2}>
              Driver's Message
                        </Col>
            <Col sm={10}>
              <FormControl type="text" 
                onChange={bindValueTo('vehicle.drivermessage')} />
            </Col>
          </FormGroup>

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