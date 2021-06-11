import React, { Component } from 'react';
import axios from 'axios';

import '../../assets/Login.css';

import Logo from '../../Images/Logo.svg'
import Medico from '../../Images/Medico.png'

class Login extends Component{
    constructor(props){
        super(props);
        this.state = {
            email : '',
            senha : ''
        }
    };

    fazerLogin = (evento) => {
        evento.preventDefault();

        this.setState({ erroMensagem : '', isLoading : true});

        axios.post('http://localhost:5000/api/login', {
            email : this.state.email,
            senha : this.state.senha

        })
    }

    atualizaCampoLogin = (campo) => {
        this.setState({ [campo.target.name] : campo.target.value })
    };

    render(){
        return(
            <main>
                <section id='login-all'>
                    <div id="foto-login">
                        <img src= {Medico} alt="Logo SPMG" id="foto"/>
                    </div>
                    <div id="login">
                        <form action="submit" id="form-login" >
                            <h2>Login</h2>
                            <input type="email" 
                            name="email" 
                            placeholder="Email" 
                            id="info-login" 
                            value={this.state.email}
                            onChange={this.atualizaCampoLogin}>
                            </input>
 
                            <input type="password"
                            name="senha" 
                            placeholder="Senha" 
                            id="info-login"
                            value={this.state.senha}
                            onChange={this.atualizaCampoLogin}>
                            </input>

                            <input type="button" value="Entrar" id="btn"></input>
                            <img src= {Logo} alt="Logo SPMG"/>
                        </form>
                    </div>
                </section>
            </main>
        )
    }
}

export default Login;
  
