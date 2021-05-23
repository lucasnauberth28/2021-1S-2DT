import React from 'react';
import './App.css';

function DataFormatada(props) {
  return <h2> Horário atual : {props.date.toLocaleTimeString()}</h2>
}


class Clock extends React.Component{
  constructor(props){
    super(props);
    this.state = {
      date : new Date()
    };
  }

  componentDidMount(){
    this.timeID = setInterval( () => {
      this.thick()
    }, 1000)
  }

  componentWillUnmount(){
    clearInterval(this.timeID)
  }

  thick()
  {
    this.setState({
      date : new Date()
    })
  }

  stopThick()
{
  clearInterval(this.timeID)
  return console.log(`Horário ${this.timeID} pausado`)
}

startThick()
{
  this.timeID = setInterval( () => {
    this.thick()
  }, 1000)

  return console.log(`Horário ${this.timeID} retomado`)
}

render()
{
  return(
    <div>
      <h1>Relógio</h1>
      <DataFormatada date={this.state.date}/>

      <div className="botoes">
        <button className="bt2" onClick={() => this.stopThick()}>PAUSAR</button>
        <button className="bt1" onClick={() => this.startThick()}>RETOMAR</button>
      </div>
    </div>
  )
}
}

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <Clock/>
        <Clock/>
      </header>
    </div>
  );
}

export default App;