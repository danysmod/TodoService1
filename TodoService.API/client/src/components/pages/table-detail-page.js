import React, { Component } from 'react'
import TableDetailItem from '../table-detail-item/table-detail-item'
import './styles/table-detail-page.css'
import {fetchTable, fetchCompleteTask, fetchDeleteTask} from '../../actions/selected-table'
import { connect } from 'react-redux';
import { compose } from 'recompose';
import withService from '../hoc/with-service'
import Spinner from '../spinner/spinner';
import TaskForm from '../task-form';
import TaskFilter from '../task-filter'

class TableDetailPage extends Component{

    componentDidMount(){
        const {id} = this.props.match.params;
        this.props.fetchTable(id);
    }

    onComplete = (taskId) => {
        const {table} = this.props

        const data = {
            TableId: table.tableId,
            TaskId: taskId
        }

        this.props.fetchCompleteTask(data);
    }

    onDelete = (taskId) => {
        const {table} = this.props

        const data = {
            TableId: table.tableId,
            TaskId: taskId
        }

        this.props.fetchDeleteTask(data);
    }

    filterItems = (items, filter) => {
        switch(filter){
            case "done": return items.filter((item) => item.state === 1)
            case "active": return items.filter((item) => item.state === 0)
            default: return items;
        }
    }

    render(){
        const {loading, title, tasks, tableId, filter} = this.props.table

        const tableWithTitle = this.props.tables.find(({tableId}) => tableId === this.props.table.tableId)

        const visibleItems = this.filterItems(tasks, filter);

        if(loading){
            return <Spinner/>
        }

        return(
            <div className="table-detail-page">
                <div className="table-detail-page-name">
                    {tableWithTitle.title}
                </div>
                <TaskFilter/>
                <div>
                    <ul className="list-group">
                    {
                        visibleItems.map((elem)=>{
                            return(
                                <li key={elem.taskId} className="list-group-item">
                                    <TableDetailItem
                                        title={elem.title}
                                        onDelete={() => this.onDelete(elem.taskId)}
                                        onComplete={() => this.onComplete(elem.taskId)}
                                        state={elem.state}/>
                                </li>
                            )
                        })
                    }
                    </ul>
                </div>
                <TaskForm tableId={tableId}/>
                <div>
                    
                </div>
            </div>
        )
    }
}

const mapStateToProps = ({table, accountDetails:{tables}}) => {
    return{table,tables}
}

const mapDispatchToProps = (dispatch, {service}) => {
    return{
        fetchTable: fetchTable(service, dispatch),
        fetchCompleteTask: fetchCompleteTask(service,dispatch),
        fetchDeleteTask: fetchDeleteTask(service,dispatch)
    }
}

export default compose(
    withService(),
    connect(mapStateToProps, mapDispatchToProps)
)(TableDetailPage)