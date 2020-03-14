import React, { Component } from 'react'
import { Redirect, Link } from 'react-router-dom'
import './styles/login-page.css'
import { connect } from 'react-redux'
import Spinner from '../spinner/spinner'

class RegisterPage extends Component{
    
    state = {
        email:undefined,
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
        console.log(this.state)
    }

    render(){
        const {username, password, email} = this.state
        const {isAuth, loading} = this.props
        
        if(isAuth) {
            return <Redirect to={{pathname: "/"}}/>
        }

        const spinner = loading ? <Spinner/> : null

        return(
            <div className="login-page">
                <form onSubmit={this.handleSubmit}>
                    <div className = "form-group">
                        <label htmlFor="email">Email</label>
                        <input
                            id="email"
                            className="form-control"
                            placeholder='Email'
                            type="email"
                            aria-describedby="emailHelp"
                            value={email}
                            onChange={this.handleChange}/>
                    </div>
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
                            Sign up
                    </button>
                    <Link to="/signin">
                        <button
                            type="button"
                            className="btn btn-outline-info btn-block register-button">
                                Sign in
                        </button>
                    </Link>
                </form>
                {spinner}
            </div>
        )
    }
}

const mapDispatchToProps = ({}) => {
    
}

const mapStateToProps = ({account:{isAuth, loading}}) => {
    return{isAuth, loading}
}

export default connect(mapStateToProps)(RegisterPage)