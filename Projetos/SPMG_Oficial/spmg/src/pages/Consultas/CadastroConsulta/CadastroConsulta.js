import React, { Component } from 'react';

class CadastroCons extends Component{
    constructor(props){
        super(props);
        this.state = {
            email : '',
            senha : '',
            erroMensagem : '',
            isLoading : false
        }
    };


}
export default CadastroCons;