import React, { Component } from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { VehicleManagementSystem } from './components/VehicleManagementSystem';
import { VehicleManager } from './components/VehicleManager';
import './custom.css'
import { NotificationContainer } from 'react-notifications';
import connectToStores from 'alt-utils/lib/connectToStores';

import AppStore from './stores/AppStore';

 class App extends Component {
  static displayName = App.name;

  static getStores() {
  return [AppStore];
}

    static getPropsFromStores() {
  return {
    state: AppStore.getState()
  };
}


  render () {
    return (
      <Layout>
        <NotificationContainer />
        <Route exact path='/' render={(props) => <Home {...props} {...this.props.state} />} />
        <Route path='/vehiclemanagementsystem'  render={(props) => <VehicleManagementSystem {...props} {...this.props.state} />} />    
               <Route path='/vehiclemanager/:vehicleId' render={(props) => <VehicleManager {...props} {...this.props.state} />} />
      </Layout>
    );
  }
}

export default connectToStores(App);