import React from 'react'
import './table-list.css'
import TableListItem from '../table-list-item'
import TableAddForm from '../table-add-form'
import { compose } from 'recompose'
import {deleteTable} from '../../actions/accountDetails'
import { connect } from 'react-redux';
import withService from '../hoc/with-service'

const TableList = ({tables, onDelete}) => {

    const onDeleteTable = (id) => {
        const data ={
            TableId : id
        }
        onDelete(data)
    }

    return(
        <ul className="table-list">
            {
                tables.map((elem) => {
                    return(
                        <li key = {elem.tableId}
                            className="table-list-item-card">
                            <TableListItem 
                                title={elem.title} 
                                id={elem.tableId}
                                onDelete={() => onDeleteTable(elem.tableId)}/>
                        </li>
                    )
                })
            }
            <TableAddForm/>
        </ul>
    )
}

const mapDispatchToProps = (dispatch, {service}) =>{
    return{
        onDelete: deleteTable(service, dispatch)
    }
}

export default compose(
    withService(),
    connect(null, mapDispatchToProps)
)(TableList)