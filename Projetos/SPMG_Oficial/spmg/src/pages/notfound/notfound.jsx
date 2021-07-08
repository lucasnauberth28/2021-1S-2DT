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
            <div>NOT FOUND</div>
        )
    }
}

export default notfound;