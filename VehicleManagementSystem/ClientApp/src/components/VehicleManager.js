import React, { Component } from 'react';
import AppActions from './../actions/AppActions';
import bindValueTo, { bindCheckedTo, bindMultiLineToArray } from '../lib/bindValueTo';
import selectn from 'selectn';
import { Button, Checkbox, Col, ControlLabel, Form, FormControl, FormGroup,Row, Glyphicon } from "react-bootstrap";
import { NotificationManager } from 'react-notifications';
import { get, put, post, del } from './../lib/http';


export class VehicleManager extends Component {
  displayName = VehicleManager.name;

  constructor(props) {
    super(props);
  }

  componentWillMount() {
    const vehicleId = selectn('match.params.vehicleId', this.props);
    VehicleManager.update(vehicleId);
  }

  componentWillReceiveProps(nextProps) {
    const vehicleId = selectn('match.params.vehicleId', nextProps);
    if (vehicleId !== selectn('match.params.vehicleId', this.props)) {
      VehicleManager.update(vehicleId);
    }
  }

  static update(vehicleId) {
    if (vehicleId === '_') {
      AppActions.updateStates([
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
        },
        { statePath: 'loading', data: false }
      ]);
      return;
    }

    get('api/vehiclemanagement/' + vehicleId, (data) =>
      AppActions.updateStates([
        { statePath: 'vehicle', data: data },
        { statePath: 'loading', data: false }
      ])
    );
  }

  save() {
    const { vehicle, history } = this.props;

    if (vehicle.id) {
      put('api/vehiclemanagement/' + vehicle.id, vehicle, () => {
        NotificationManager.success('Vehicle saved');
        VehicleManager.update(vehicle.id);
      });

      return;
    }

    post('api/vehiclemanagement', vehicle, (content) => {
      NotificationManager.success('Vehicle created');
      history.push(`/vehiclemanager/${content.id}`);
    });
  }

  render() {
    const { loading, vehicle } = this.props;
    const vehicleId = selectn('match.params.vehicleId', this.props);

    return (
      <div>
        <h1>Vehicle Manager</h1>

        <pre>{JSON.stringify(vehicle, null, 2)}</pre>
        {vehicle && <Form horizontal>
          <FormGroup controlId="Name">
            <Col componentClass={ControlLabel} sm={2} >
              Name
                        </Col>
            <Col sm={10}>
              <FormControl type="text" value={vehicle.name}
                onChange={bindValueTo('vehicle.name')} />
            </Col>
          </FormGroup>
          <FormGroup controlId="speed">
            <Col componentClass={ControlLabel} sm={2}>
              Speed
                        </Col>
            <Col sm={10}>
              <FormControl type="number" value={vehicle.speed}
                onChange={bindValueTo('vehicle.speed')}  />
            </Col>
          </FormGroup>
          <FormGroup controlId="latitude">
            <Col componentClass={ControlLabel} sm={2}>
              Latitude
                        </Col>
            <Col sm={10}>
              <FormControl type="number" value={vehicle.latitude}
                onChange={bindValueTo('vehicle.latitude')} />
            </Col>
          </FormGroup>
  
 
          <FormGroup controlId="longitude">
            <Col componentClass={ControlLabel} sm={2}>
              Longitude
                        </Col>
            <Col sm={10}>
              <FormControl type="number" value={vehicle.longitude}
                onChange={bindValueTo('vehicle.longitude')} />
            </Col>
          </FormGroup>
        

          <FormGroup controlId="temperature">
            <Col componentClass={ControlLabel} sm={2}>
              Temperature
                        </Col>
            <Col sm={10}>
              <FormControl type="number" value={vehicle.temperature}
                onChange={bindValueTo('vehicle.temperature')} />
            </Col>
          </FormGroup>
          <FormGroup controlId="Pressure">
            <Col componentClass={ControlLabel} sm={2}>
              Pressure
                        </Col>
            <Col sm={10}>
              <FormControl type="number" value={vehicle.pressure}
                onChange={bindValueTo('vehicle.pressure')} />
            </Col>
         
          </FormGroup>
          <FormGroup controlId="drivermessage">
            <Col componentClass={ControlLabel} sm={2}>
              Driver's Message
                        </Col>
            <Col sm={10}>
              <FormControl type="text" value={vehicle.drivermessage}
                onChange={bindValueTo('vehicle.drivermessage')} />
            </Col>
          </FormGroup>
          <FormGroup>
            <Col smOffset={2} sm={10}>
              <Button onClick={() => this.save()}>Save</Button>
            </Col>
          </FormGroup>
        </Form>}


        {vehicle && vehicle.id && <Button bsStyle="danger" bsSize="xsmall" onClick={() => this.del()}>Delete</Button>}
      </div>
    );
  }


  del() {
    const { history, vehicle } = this.props;

    if (window.confirm("Do you really want to delete this?")) {
      del('api/vehiclemanagement/' + vehicle.id, () => {
        NotificationManager.success('Vehicle deleted');
        history.push('/vehiclemanager');
      });
    }
  }
}

VehicleManager.defaultProps = {
  loading: false,
  vehicle: null
};