import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import './custom.css'
import { Login } from './components/Account/Login';
import { Home } from './components/Main/Home';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Login} />
        <Route exact path='/Home' component={Home} />
      </Layout>
    );
  }
}