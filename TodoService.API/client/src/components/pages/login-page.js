import React, { Component } from 'react'
import './styles/login-page.css'
import {fetchUser} from '../../actions/account'
import {connect} from 'react-redux'
import { compose } from 'recompose'
import withService from '../hoc/with-service'
import { Link, Redirect } from 'react-router-dom'
import Spinner from '../spinner/spinner'

class LoginPage extends Component{
    state = {
        username: undefined,
        password: undefined
    }

    handleChange = event => {
        this.setState({
          [event.target.id]: event.target.value
        });
    }

    handleSubmit = (event) => {
        event.preventDefault();
        this.props.fetchUser(this.state)
    }

    render(){
        const {username, password} = this.state
        const {isAuth, loading} = this.props
        
        if(isAuth) {
            return <Redirect to={{pathname: "/"}}/>
        }

        const spinner = loading ? <Spinner/> : null

        return(
            <div className="login-page">
                <form onSubmit={this.handleSubmit}>
                    <div className = "form-group">
                        <label htmlFor="username">Username</label>
                        <input
                            id="username"
                            className="form-control"
                            placeholder='Username'
                            value={username}
                            onChange={this.handleChange}/>
                    </div>
                    <div className="form-group">
                        <label htmlFor="password">Password</label>
                        <input
                            id="password" 
                            className="form-control"
                            type="password"
                            placeholder="Password"
                            value={password}
                            onChange={this.handleChange}/>
                    </div>    
                    <button
                        type="submit"
                        className="btn btn-primary btn-block">
                            Sign in
                    </button>
                    <Link to="/signup">
                        <button
                            type="button"
                            className="btn btn-outline-info btn-block register-button">
                                Sign up
                        </button>
                    </Link>
                </form>
                {spinner}
            </div>
        )
    }
}
const mapStateToProps = ({account:{isAuth, loading}}) =>{
    return{isAuth, loading}
}

const mapDispatchToProps =(dispatch, {service}) => {
    return{
        fetchUser: fetchUser(service,dispatch)
    }
}


export default compose(
    withService(),
    connect(mapStateToProps,mapDispatchToProps)
)(LoginPage)