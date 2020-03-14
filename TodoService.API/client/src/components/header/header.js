import React from 'react'
import { connect } from 'react-redux';
import {logoutUser} from '../../actions/account'
import {Link} from 'react-router-dom'
import './header.css'

const UserPanel = ({username, getOut}) => {
    return(
        <div className="nickname text-light text-center">
            {username}
            <button 
                type="button"
                className="btn btn-dark float-right"
                onClick={() => getOut()}>
                Get out
            </button>
        </div>
    )
}

const Header =  ({username, getOut, isAuth}) => {
    const userPanel = isAuth 
        ? <UserPanel username={username} getOut={getOut}/>
        : null
    return (
        <header className="todo-header">
            <Link to="/">
                <div className="logo text-light">
                    <i className="logo-icon fa fa-list-alt"/>
                    Todo-service
                </div>
            </Link>
            {userPanel}
        </header>
    )
}

const mapStateToProps = ({account:{isAuth}, accountDetails: {username}}) => {
    return{isAuth, username}
}

const mapDispatchToProps = {
    getOut: logoutUser
}

export default connect(mapStateToProps,mapDispatchToProps)(Header);
