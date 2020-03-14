import updateUser from './user'
import updateAccountDetails from './account-details'
import updateTable from './table';

const reducer = (state, action) => {
    return{
        account: updateUser(state,action),
        accountDetails: updateAccountDetails(state,action),
        table: updateTable(state,action)
    }
}

export default reducer;