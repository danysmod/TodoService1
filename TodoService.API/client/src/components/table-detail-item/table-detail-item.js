import React from 'react'
import './table-detail-item.css'

export default ({title, state, onComplete, onDelete}) => {
    let className = "table-detail-item";
    
    let changeStateButton = (
        <button type="button"
            className="btn btn-outline-success btn-sm float-right"
            onClick={onComplete}>
            <i class="fa fa-thumbs-up"></i>
        </button>
    )

    if(state == 1){
        className += ' done';
        changeStateButton = (
            <button type="button" 
                className="btn btn-outline-warning btn-sm float-right"
                onClick={onComplete}>
                <i class="fa fa-list-alt"></i>
            </button>
        )
    }
    if(state == 2){
        return;
    }

    console.log(state);

    return(
        <span className={className}>
            <span className="table-detail-item-label">
                <i class="fa fa-check item-state"></i>
                {title}
            </span>
            {changeStateButton}

            <button type="button"
                    className="btn btn-outline-danger btn-sm float-right"
                    onClick={onDelete}>
                <i className="fa fa-trash-o"></i>
            </button>
        </span>
    )
}