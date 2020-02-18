import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { VehicleManagementSystem } from './components/VehicleManagementSystem';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route path='/' component={VehicleManagementSystem} />
      </Layout>
    );
  }
}
