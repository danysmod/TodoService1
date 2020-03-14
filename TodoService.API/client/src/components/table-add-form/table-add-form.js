import React, {useState} from 'react'
import {Modal} from 'react-bootstrap';
import './table-add-form.css'
import { compose } from 'recompose';
import { connect } from 'react-redux';
import { createTable } from '../../actions/accountDetails';
import withService from '../hoc/with-service'

const TableAddForm = ({addTable}) => {

    const [show, setShow] = useState(false);
    const [title,setTitle] = useState('');

    const handleClose = () => {
        setShow(false);
        setTitle('');
    }

    const handleShow = () => setShow(true);

    const handleChange = (e) => {
        setTitle(e.target.value);
    }

    const handleSubmit = (event) => {
        event.preventDefault();
        
        const data = { 
            TableName: title
        }
        
        addTable(data);
        handleClose();
    }

    return(
        <div>
            <button onClick={handleShow}>Add table</button>
            <Modal show={show} onHide={handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title>New table</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <form onSubmit={handleSubmit}>
                        <div className = "form-group">
                            <label htmlFor="username">Table name</label>
                            <input
                                id="title"
                                className="form-control"
                                placeholder='Title'
                                value={title}
                                onChange={handleChange}/>
                        </div>
                        <button type="submit"
                                className="btn btn-primary">Add</button>
                        <button type="button"
                                className="btn btn-dark"
                                onClick={handleClose}>Close</button>
                    </form>
                </Modal.Body>
            </Modal>
        </div>
    )
}

const mapDispatchToProps = (dispatch,{service}) => {
    return{
        addTable: createTable(service, dispatch)
    }
}

export default compose(
    withService(),
    connect(null,mapDispatchToProps)
)(TableAddForm)