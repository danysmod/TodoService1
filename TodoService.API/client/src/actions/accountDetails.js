const accountDetailsLoaded = (accountData) => {
    return{
        type:"FETCH_ACCOUNT_SUCCESS",
        payload: accountData
    }
}

const accountDetailsRequest = () => {
    return{
        type: "FETCH_ACCOUNT_REQUEST"
    }
}

const accountDetailsError = (error) => {
    return{
        type:"FETCH_ACCOUNT_ERROR",
        payload:error
    }
}

const addTable = (tableData) =>{
    return{
        type: "ADD_TABLE",
        payload: tableData
    }
}

const createTable = (service, dispatch) => (data) =>{
    const token = localStorage.getItem('token')
    if(token){
        service.createTable(token, data)
            .then((tableData) => {
                dispatch(addTable(tableData.tableModel))
            })
            .catch((err)=> dispatch(accountDetailsError(err)))
    }
}

const removeTable = (table) => {
    return{
        type: "DELETE_TABLE",
        payload: table
    }
}

const deleteTable = (service, dispatch) => (data) => {
    const token = localStorage.getItem('token')
    if(token){
        service.deleteTable(token, data)
            .then((tableData) => dispatch(removeTable(tableData)))
            .catch((err) => dispatch(accountDetailsError(err)))
    }
}

const fetchAccountDetails = (service, dispatch) => () => {
    dispatch(accountDetailsRequest());
    const token = localStorage.getItem('token')
    if(token){
        service.getAccountDetails(token)
            .then((items) => dispatch(accountDetailsLoaded(items.accountDetails)))
            .catch((err) => dispatch(accountDetailsError(err)));
    }
}

const fetchTableDetails = (service, dispatch) => (id) => {
    const token = localStorage.getItem('token');
    if(token){
        service.getTableDetails(token, id)
            .then((items) => console.log(items));
    }
}

export{
    fetchAccountDetails,
    fetchTableDetails,
    createTable,
    deleteTable
}