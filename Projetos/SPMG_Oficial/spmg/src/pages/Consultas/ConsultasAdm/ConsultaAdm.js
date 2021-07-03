import axios from 'axios';
import React, { Component } from 'react';
import '../../../assets/ConsultaAdm.css'

import logo from '../../../Images/Logo.png'

// function DataFormatada(props) {
//     return new Intl.DateTimeFormat('pt-BR', {day: 'numeric', month:'long', year: 'numeric'}).format()
//   }
  

class ConsultaAdm extends Component{
    constructor(props){

        super(props);
        this.state = 
        {
          listaCons : [], 
        }
    };

    buscaPaciente = () => {
        axios('')
    }

    componentDidMount()
    {
        this.listaCons();
    }

    listaCons = () => 
    {
        console.log('nauberth')

        fetch('http://localhost:5000/api/consultas/minhas',
        {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

        .then(resposta => resposta.json())

        .then(resposta => this.setState({ listaCons : resposta }))

        .catch((erro) => console.log(erro))
    }

    Logout = () => 
    {
        localStorage.removeItem('usuario-login')
    }  
      
    render(){
        return( 
        <div>
            <header id='header'>
                <nav id='nav'>
                    <button id="btn">
                        <span id="hamburger"> 
                        </span>
                    </button>
                    <ul id="menu">
                        <li><a href='http://localhost:3000/consultas/administrador'>Consultas</a></li>
                        <li><a href='http://localhost:3000/consultas/cadastro'> Cadastrar Consulta</a></li>
                        <li><a onClick={this.Logout} href='http://localhost:3000/'>Sair</a></li>
                        <div className='modes'></div>
                            <input type='checkbox' id="switch"/>
                            <label for='switch' className='label'>
                            <i className='fas fa-moon'></i>
                            <i className='fas fa-sun'></i>
                            <div className='ball'></div>
                            </label>
                    </ul>
                </nav>
                <img src={logo} id="logo"/>
            </header>
            <main>
                <div id='textos'>
                    <h2>Administrador</h2>
                <h4 id="linha"></h4>
                    <p>Veja as consultas do SP Medical Group</p>
                </div>

                {this.state.listaCons.map((consulta) => {
                return(

                 <section id="consultas" key={ConsultaAdm.IdConsulta}>
                    <div id="consulta">
                        <ul id="list-consulta">
                        <li><i class="fas fa-user"></i><a href="#">{}</a></li>
                        <li><i class="fas fa-briefcase-medical"></i><a href="#">Médico</a></li>
                        <li><i class="fas fa-clock"></i><a href="#">Situação</a></li>
                        <li><i class="fas fa-calendar-day"></i><a href="#">Data</a></li>
                        </ul>
                    </div>
                </section>
                )
                })}
               
            </main>
        </div>
    )}
}    
export default ConsultaAdm;