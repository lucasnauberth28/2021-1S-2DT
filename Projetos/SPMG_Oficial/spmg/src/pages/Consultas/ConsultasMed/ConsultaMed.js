import React,{ Component } from 'react';
import '../../../assets/ConsultaMed.css'

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

class ConsultaMed extends Component{
    constructor(props){
        super(props);
        this.state = {
            listaMedico: [],
            idConsultaAlterada: 0,
            descricao: "",
        }
    };

    componentDidMount(){
        this.listaMedico();
    }

    listaMedico = () => 
    {
        console.log('nauberth')

        fetch('http://localhost:5000/api/consultas/medico',
        {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

        .then(resposta => resposta.json())

        .then(resposta => this.setState({ listaMedico : resposta }))

        .catch((erro) => console.log(erro))
    };

    atualizaDesc = (consulta) => {
        this.setState(
            {
                idConsultaAlterada : consulta.idConsulta,
            },
            () => {
                console.log(
                    "lucas"
                );
                this.buscarConsultasMedico();
            }
        );
    };

    atualizaEstadoDesc = async (event) => {
        await this.setState({descricao: event.target.value });
        console.log(this.state.descricao)
    };

    Logout = () => 
    {
        localStorage.removeItem('usuario-login')
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
                        <li><a href='http://localhost:3000/consultas/medico'>Consultas</a></li>
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
                    <h2>Doutor</h2>
                <h4 id="linha"></h4>
                    <p>Veja as consultas do SP Medical Group</p>
                </div>

                {this.state.listaMedico.map((consultas) => {
                return(

                 <section id="consultas" key={consultas.IdConsulta}>
                    <div id="consulta">
                            <ul id="list-consulta">
                            <li><i class="fas fa-user"></i><a href="#">{consultas.idPacienteNavigation.nomePaciente}</a></li>
                            <li><i class="fas fa-briefcase-medical"></i><a href="#">{consultas.idMedicoNavigation.nomeMedico}</a></li>
                            <li><i class="fas fa-clock"></i><a href="#">{consultas.idSituacaoNavigation.situacao1}</a></li>
                            <li><i class="fas fa-calendar-day"></i><a href="#">{Intl.DateTimeFormat("pt-BR").format(new Date(consultas.dataConsulta))}</a></li>
                        </ul>
                        <div id="desc">
                            <li id="descricao"><i class="fas fa-comment-alt"></i><a>{consultas.descricao}</a></li>
                            <button id="cancel-btn">Editar</button>
                        </div>
                    </div>
                </section>
                )
                })}
            </main>
        </div>
        )
    }
}

 export default ConsultaMed;