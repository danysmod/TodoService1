import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { BrowserRouter as Router } from 'react-router-dom';

import App from './components/app'
import TodoService from './services/real-todo-service'
import {ServiceProvider} from './components/todo-service-context'

import store from './store'

const todoService = new TodoService();

ReactDOM.render(
    <Provider store={store}>
        <ServiceProvider value={todoService}>
            <Router>
                <App/>
            </Router>
        </ServiceProvider>
    </Provider>, 
    document.getElementById('root')
);
