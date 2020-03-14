import React from 'react'
import { withRouter } from 'react-router-dom';
import './table-list-item.css'

const TableListItem = ({title, id, history, onDelete}) => {
    return(
        <div className="card table-list-item">
            <a onClick={() => history.push(`/table/${id}`)}>
                <span className="table-name">{title}</span>
            </a>
            <button type="button"
                    className="btn btn-danger btn-sm float-right"
                    onClick={onDelete}>
                <i className="fa fa-trash-o"></i>
            </button>
        </div>
    )
}

export default withRouter(TableListItem);