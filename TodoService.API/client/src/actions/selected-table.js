const tableRequest = () => {
    return{
        type: 'FETCH_TABLE_REQUEST'
    }
}

const tableLoaded = (tableData) => {
    return{
        type: 'FETCH_TABLE_SUCCESS',
        payload: tableData
    }
}

const tableError = (err) => {
    return{
        type: 'FETCH_TABLE_ERROR',
        payload: err
    }
}

const completeTask = (task) => {
    return{
        type:"COMPLETE_TASK",
        payload: task
    }
}

const deleteTask = (task) => {
    return{
        type: "DELETE_TASK",
        payload: task
    }
}

const addTask = (task) => {
    return{
        type: "ADD_TASK",
        payload:task
    }
}

const fetchCompleteTask = (service, dispatch) => (data) =>{
    const token = localStorage.getItem('token');
    if(token){
        service.completeTask(token, data)
            .then((data) => dispatch(completeTask(data)))
            .catch((err) => dispatch(tableError(err)))
    }
} 

const fetchDeleteTask = (service, dispatch) => (data) =>{
    const token = localStorage.getItem('token');
    if(token){
        service.deleteTask(token, data)
            .then((data) => {
                console.log(data);
                dispatch(deleteTask(data))})
            .catch((err) => dispatch(tableError(err)))
    }
} 

const fetchAddTask = (service, dispatch) => (data) => {
    const token = localStorage.getItem('token')
    if(token){
        service.addTask(token, data)
            .then((data) => {
                console.log(data.tableTask);
                dispatch(addTask(data.tableTask))
            })
            .catch((err) => dispatch(tableError(err)))
    }
}

const fetchTable = (service, dispatch) => (id) => {
    dispatch(tableRequest());
    const token = localStorage.getItem('token');
    if(token){
        service.getTableDetails(token, id)
            .then((data) => dispatch(tableLoaded(data.tableDetails)))
            .catch((err) => dispatch(tableError(err)))
    }
} 

const filterChanged = (filterType) => {
    return{
        type: "FILTER_CHANGED",
        payload: filterType
    }
}

export{
    fetchTable,
    fetchCompleteTask,
    fetchDeleteTask,
    fetchAddTask,
    filterChanged
}