import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { FetchData } from './components/FetchData';
import { AddIncident } from './components/AddIncident';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={FetchData} />
        <Route path='/add-incident' component={AddIncident} />
      </Layout>
    );
  }
}
