import '../../assets/Login.css';
import React, { Component } from 'react';
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

    render(){
        return(
            <main>
                <section id='login-all'>
                    <div id="foto-login">
                        <img src= {Medico} alt="Logo SPMG" id="foto"/>
                    </div>
                    <div id="login">
                        <form action="submit" id="form-login">
                            <h2>Login</h2>
                            <input type="email" 
                            name="email" 
                            placeholder="Email" 
                            id="info-login" 
                            value={this.state.email}>
                            </input>

                            <input type="password" 
                            placeholder="Senha" 
                            id="info-login">
                            
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
  
