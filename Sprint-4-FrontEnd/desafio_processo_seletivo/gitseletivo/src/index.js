import React from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter, Switch, Redirect } from 'react-router-dom'; 

import './index.css';

import App from './App';
import home from './pages/Home/home';
import notFound from './pages/NotFound/404';

import reportWebVitals from './reportWebVitals';

const routing = (
  <BrowserRouter>
    <div>
      <Switch>
        <Route exact path="/" component={App} />
        <Route path="/pesquisa" component={home} />
        <Route path="/erro" component={notFound} />
        <Redirect to="/erro"/> 
      </Switch>
    </div>
  </BrowserRouter>
)

ReactDOM.render(routing, document.getElementById('root')
);

reportWebVitals();
