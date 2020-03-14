const updateTaskItem = (tasks, item, idx) => {

    if (item.state === 2) {
      return [
        ...tasks.slice(0, idx),
        ...tasks.slice(idx + 1)
      ];
    }
  
    if (idx === -1) {
      return [
        ...tasks,
        item
      ];
    }
  
    return [
      ...tasks.slice(0, idx),
      item,
      ...tasks.slice(idx + 1)
    ];
};

const updateTask = (newTask, item = {}, taskState = 2) => {

    const {
        taskId = newTask.taskId,
        title = newTask.title
    } = item

    return{
        taskId,
        title,
        state: taskState
    }
}

const updateTasks = (state, item) => {
    const {table} = state;
    
    const idx = table.tasks.findIndex(({taskId}) => taskId == item.taskId)
    const itemList = table.tasks[idx]

    const newTask = updateTask(item, itemList, item.state)
    return {
        ...state.table,
        tasks: updateTaskItem(table.tasks, newTask, idx)
    }
}


const updateTable = (state, action) => { 

    if(state === undefined){
        return {
            tableName : null,
            tableId : null,
            tasks:[],
            loading: true,
            error: null,
            filter: 'all'
        }
    }

    switch(action.type){
        case "COMPLETE_TASK": return updateTasks(state, action.payload)
        case "DELETE_TASK": return updateTasks(state, action.payload)
        case "ADD_TASK": return updateTasks(state, action.payload)
        case "FILTER_CHANGED": return{
            ...state.table,
            filter:action.payload
        }
        case "FETCH_TABLE_REQUEST": return{
            tableName : null,
            tableId : null,
            tasks:[],
            loading: true,
            error: null,
            filter: 'all'
        }
        case "FETCH_TABLE_SUCCESS": return{
            tableName : action.payload.tableName,
            tableId : action.payload.tableId,
            tasks: action.payload.tasks,
            loading: false,
            error: null,
            filter: 'all'
        }
        case "FETCH_TABLE_ERROR": return{
            tableName : null,
            tableId : null,
            tasks:[],
            loading: false,
            error: action.payload,
            filter: 'all'
        }
        case "LOGOUT_USER": return{
            tableName : null,
            tableId : null,
            tasks:[],
            loading: true,
            error: null,
            filter: 'all'
        }
        default: return state.table
    }
}

export default updateTable;