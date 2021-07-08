import React, { Component } from 'react';
import axios from 'axios';
import '../../../assets/CadastroConsulta.css'

import logo from '../../../Images/Logo.png'
import logoDark from '../../../Images/LogoDark.svg'

function toggleMenu(){
    const nav = document.getElementById('nav');
    nav.classList.toggle('active');
}

function Dark(){
    const html = document.querySelector('html');
    const checkbox = document.querySelector('#switch');

    checkbox.addEventListener('change', function(){
    html.classList.toggle('dark-mode');
});

};

class CadastroCons extends Component{
    constructor(props){
        super(props);
        this.state = {
            idConsulta: 0,
            idMedico: 0,
            listaMedico: [],
            idPaciente: 0,
            listaPaciente: [],
            situacao: 0,
            listaSituacoes: [],
            dataConsulta: (new Date()).getFullYear(),
            descricao: '',
            isLoading: false,
        } }
        
        componentDidMount(){
        this.buscarMedicos();
        this.buscarPacientes();
    }

        buscarMedicos = () => {
            axios('http://localhost:5000/api/medico', {
              headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
              }
            })
              .then(resposta => {
                if (resposta.status === 200) {
                  this.setState({ listaMedico: resposta.data })
                  console.log(this.state.listaMedico)
                }
              })
        
              .catch(erro => console.log(erro))
          }

          buscarPacientes = () => {
            axios('http://localhost:5000/api/paciente', {
              headers: {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
              }
            })
              .then(resposta => {
                if (resposta.status === 200) {
                  this.setState({ listaPaciente: resposta.data })
                  console.log(this.state.listaPaciente)
                }
              })
              .catch(erro => console.log(erro))
          } 
    ;  
  

    cadastrarConsulta = (event) => {
        event.preventDefault();
        this.setState({ isLoading: true })
    
        let consulta = {
          idMedico: this.state.idMedico,
          idPaciente: this.state.idPaciente,
          idSituacao: this.state.situacao,
          dataConsulta: this.state.dataConsulta,
          descricao: ''
        }

        axios.post('http://localhost:5000/api/consultas', consulta, {
        headers : {
          'Authorization' : 'Bearer' + localStorage.getItem('usuario-login')
        }
      })
  
        .then(resposta => {
          if (resposta.status === 201) {
            console.log('Consulta cadastrada!')
            this.setState({ isLoading: false })
          }
        })
        .catch(erro => {
          console.log(erro);
          this.setState({ isLoading: false })
        });
    }
        atualizaStateCampo = async (campo) => {
            await this.setState({ [campo.target.name] : campo.target.value })
          }

          render(){
        return(
            <div className="div">
            <header id='header'>
                <nav id='nav'>
                    <button id="btn" onClick={toggleMenu}>
                        <span id="hamburger"> 
                        </span>
                    </button>
                    <ul id="menu">
                        <li><a href='http://localhost:3000/consultas/administrador'>Consultas</a></li>
                        <li><a href='http://localhost:3000/consultas/cadastro'> Cadastrar Consulta</a></li>
                        <li><a onClick={this.Logout} href='http://localhost:3000/'>Sair</a></li>
                        <div className='modes'></div>
                            <input type='checkbox' id="switch" onClick={Dark} />
                            <label for='switch' className='label'>
                            <i className='fas fa-moon'></i>
                            <i className='fas fa-sun'></i>
                            <div className='ball'></div>
                            </label>
                    </ul>
                </nav>
                <img src={logo} id="logo"/>
                <img src={logoDark} id="logoDark"/>
            </header>
            <main>
                <div id='textos'>
                    <h2>Administrador</h2>
                <h4 id="linha"></h4>
                    <p>Agende novas consultas</p>
                </div>
                <form onSubmit={this.cadastrarConsulta}>
                <section id="cadastro-consultas">
                    <div id="cad-consulta">
                            <ul id="cad-list-consulta">
                            <li><i class="fas fa-user"></i><input name="idPaciente"
                                                            value={this.state.idPaciente} 
                                                             onChange={this.atualizaStateCampo}/></li>
                            <li><i class="fas fa-briefcase-medical"></i>
                                                            <input name="idMedico"
                                                            value={this.state.idMedico} 
                                                             onChange={this.atualizaStateCampo}/></li>
                            <li><i class="fas fa-calendar-day"></i> <input type="date"
                                                            name="dataConsulta"
                                                            value={this.state.dataConsulta}
                                                            onChange={this.atualizaStateCampo}/></li>
                        </ul>
                        </div>
                    <button id="btn-cad-con" type="submit">
                    <i class="fas fa-check-circle"></i>Cadastrar</button>
                </section>
                </form>
            </main>
        </div>)}
    };
export default CadastroCons;