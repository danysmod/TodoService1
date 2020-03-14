const updateTables = (tables, item, idx) => {

    if (item.state === 1) {
        return [
          ...tables.slice(0, idx),
          ...tables.slice(idx + 1)
        ];
      }
    
      if (idx === -1) {
        return [
          ...tables,
          item
        ];
      }
    
      return [
        ...tables.slice(0, idx),
        item,
        ...tables.slice(idx + 1)
      ];
}

const updateItem = (newTable, oldItem={}, stateItem = 1) =>{

    const{
        title = newTable.title,
        tableId = newTable.tableId,
    } = oldItem

    console.log(oldItem)

    return{
        title,
        tableId,
        state: stateItem
    }
}


const updateItems = (state, newTable) => {

    console.log(newTable);
    const{accountDetails: {tables}} = state
    console.log(tables);
    const idx = tables.findIndex(({tableId}) => tableId === newTable.tableId);
    const item = tables[idx];

    console.log(idx)
    console.log(item)

    const newItem = updateItem(newTable, item, newTable.state)

    console.log(newItem);
    return{
        ...state.accountDetails,
        tables: updateTables(tables, newItem, idx),
        loading:false
    }
}

const updateAccountDetails = (state, action) => {
    
    if(state === undefined){
        return{
            tables:{},
            username:null,
            loading:true
        }
    }

    switch(action.type){
        case "FETCH_ACCOUNT_SUCCESS":
            return{
                tables: action.payload.tables,
                username: action.payload.name,
                loading:false
            }
        case "FETCH_ACCOUNT_REQUEST": return {
            ...state.accountDetails,
            loading: true
        }
        case "LOGOUT_USER":return{
                tables:{},
                username:null,
                loading:true
            }
        case "ADD_TABLE": return updateItems(state, action.payload)
        case "DELETE_TABLE": return updateItems(state, action.payload)
        default: return state.accountDetails;
    }
}

export default updateAccountDetails;