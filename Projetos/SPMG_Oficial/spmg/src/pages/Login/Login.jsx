import React, { Component } from 'react';
import axios from 'axios';
import { parseJwt, usuarioAutenticado } from '../../services/auth';

import '../../assets/Login.css';

import Logo from '../../Images/Logo.svg'
import Medico from '../../Images/Medico.png'

class Login extends Component{
    constructor(props){
        super(props);
        this.state = {
            email : '',
            senha : '',
            erroMensagem : '',
            isLoading : false
        }
    };

    fazerLogin = (event) => {
        event.preventDefault();
        this.setState({ erroMensagem : '', isLoading : true});

        axios.post('http://localhost:5000/api/login', {
            email : this.state.email,
            senha : this.state.senha

        })
        
        .then(resposta => {
        if (resposta.status === 200) {
            localStorage.setItem('usuario-login', resposta.data.token);
            console.log('Meu token é:' + resposta.data.token);
            this.setState({ isLoading : false})

            let base64 = localStorage.getItem('usuario-login').split('.')[1];
            console.log(base64);
            console.log(window.atob(base64));

            console.log(JSON.parse(window.atob(base64)));
                      
            console.log(parseJwt().role);

            if(parseJwt().role === '1') {
                this.props.history.push('/consultas/administrador');
                console.log("estou logado: "+ usuarioAutenticado());

            }
            else if(parseJwt().role === "2")
              {
                console.log('estou logado: ' + usuarioAutenticado());
                this.props.history.push('/consultas/medico')

            }else if(parseJwt().role === "3")
              {
                console.log('estou logado: ' + usuarioAutenticado());
                this.props.history.push('/consultas/paciente')

            }
        }})

        .catch(() => {
            this.setState({ erroMensagem : 'E-mail ou senha inválidos! Tente novamente.', isLoading : false});
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
                        <form action="submit" id="form-login" onSubmit={this.fazerLogin} >
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

                            <p style={{ color : '#C1313A'}}>{this.state.erroMensagem}</p>

                            <input type="submit" value="Entrar" id="btn-login"></input>
                            <img src= {Logo} alt="Logo SPMG"/>
                        </form>
                    </div>
                </section>
            </main>
        )
    }
}
export default Login;