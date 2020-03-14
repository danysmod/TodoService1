import React, { Component } from 'react';
import Header from '../header';
import Routes from '../../routes';
import './app.css'

class App extends Component {
    
    render(){
        return (
            <div>
                <Header/>
                <Routes/>
            </div>
        )
    }
}

export default App