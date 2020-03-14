const loginUser = (userData) => {
    return{
        type: "LOGIN_USER",
        payload: userData
    }
}

const loginUserRequest = () => {
    return{
        type: "LOGIN_USER_REQUEST"
    }
}

const logoutUser = () => {
    localStorage.removeItem('token')
    return{
        type: "LOGOUT_USER"
    }
}

const loginUserError = (error) => {
    return{
        type: "LOGIN_USER_ERROR",
        payload: error
    }
}

const registerUser = (service, dispatch) => (data) => {
    dispatch(loginUserRequest())
    service.register(data)
        .then((data) => {
            localStorage.setItem("token", data.token)
            dispatch(loginUser(data.accountId))
        })
        .catch((error) => loginUserError(error))
}

const fetchUser = (service, dispatch) => (data) => {
    dispatch(loginUserRequest())
    service.login(data)
        .then((data) => {
            localStorage.setItem("token", data.token)
            dispatch(loginUser(data.accountId))
        })
        .catch((error) => loginUserError(error))
}

export{
    loginUser,
    fetchUser,
    logoutUser,
    registerUser
}