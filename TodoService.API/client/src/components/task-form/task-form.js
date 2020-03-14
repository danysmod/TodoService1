import React, { Component } from 'react'
import './task-form.css'
import {fetchAddTask} from '../../actions/selected-table'
import { connect } from 'react-redux';
import withService from '../hoc/with-service'
import { compose } from 'recompose';

class TaskForm extends Component {

    state = {
        title: ''
    }

    onTitleChange = (e) =>{
        console.log(e.target)
        this.setState({
            title: e.target.value
        })
    }

    onSubmit = (e) => {
        e.preventDefault();
        const { title } = this.state;
        this.setState({ title: '' });

        const data ={
            TableId:this.props.tableId,
            Title: title
        }

        this.props.fetchAddTask(data);
      };

    render(){
        return (
            <form
              className="bottom-panel d-flex"
              onSubmit={this.onSubmit}>
      
              <input type="text"
                     className="form-control new-todo-label"
                     value={this.state.title}
                     onChange={this.onTitleChange}
                     placeholder="What needs to be done?" />
      
              <button type="submit"
                      className="btn btn-outline-secondary">Add</button>
            </form>
        );
    }
}

const mapDispatchToProps = (dispatch,{service}) =>{
    return{
        fetchAddTask: fetchAddTask(service,dispatch)
    }
}
export default compose(
    withService(),
    connect(null,mapDispatchToProps)
)(TaskForm)