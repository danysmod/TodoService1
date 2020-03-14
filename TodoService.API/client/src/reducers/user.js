const updateUser = (state, action) => {
    
    if(state === undefined){
        return{
            accountId: null,
            isAuth: false,
            loading: false
        }
    }

    switch(action.type){
        case "LOGIN_USER": 
            return {
                accountId: action.payload,
                isAuth: true,
                loading: false
            }
        case "LOGIN_USER_REQUEST":
            return{
                ...state.account,
                loading: true
            }            
        case "LOGOUT_USER":
            return {
                accountId: null,
                isAuth: false,
                loading: false
            }
        default : 
            return state.account;
    }
}

export default updateUser;