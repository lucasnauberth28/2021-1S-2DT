import React, { Component } from 'react';

class notfound extends Component{
    constructor(props){
        super(props);
        this.state = {
            email : '',
            senha : '',
            erroMensagem : '',
            isLoading : false
        }
    };

    render(){
        return( 
            <div> notfound lol</div>
        )
    }
}

export default notfound;