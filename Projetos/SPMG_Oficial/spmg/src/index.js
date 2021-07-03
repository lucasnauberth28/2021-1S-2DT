import React from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router, Switch, Redirect } from 'react-router-dom';

//Estilos
import './index.css';

//pages
import Login from './pages/Login/Login';
import ConsultasAdm from './pages/Consultas/ConsultasAdm/ConsultaAdm';
import ConsultasMed from './pages/Consultas/ConsultasMed/ConsultaMed';
import ConsultasPac from './pages/Consultas/ConsultasPac/ConsultaPac';
import CadastroCons from '../src/pages/Consultas/CadastroConsulta/CadastroConsulta';
import notfound from './pages/notfound/notfound'

const routing = (
  <Router > 
    <div> 
      <Switch>
      <Route exact path="/" component={Login} />,
      <Route exact path='/consultas/administrador' component={ConsultasAdm}/>
      <Route exact path='/consultas/cadastro' component={CadastroCons}/>
      <Route exact path='/consultas/medico' component={ConsultasMed}/>
      <Route exact path='/consultas/paciente' component={ConsultasPac}/>
      <Route exact path='/notfound' component={notfound}/>
      <Redirect to="/notfound"/>
      </Switch>
    </div>
  </Router>
)
ReactDOM.render(routing, document.getElementById('root'));