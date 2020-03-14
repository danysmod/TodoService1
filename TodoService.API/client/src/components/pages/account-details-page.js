import React, { Component } from 'react'
import TableList from '../table-list'

import {fetchAccountDetails} from '../../actions/accountDetails'
import { connect } from 'react-redux';
import withService from '../hoc/with-service'

import {compose} from 'recompose'
import Spinner from '../spinner/spinner';

class AccountDetailsPage extends Component {
    
    componentDidMount(){
        this.props.fetchAccountDetails();
    }

    render(){
        const {tables, loading} = this.props

        const spinner = loading ? <Spinner/> : null
        const tableList = loading ? null : <TableList tables={tables}/>
        return(
            <div>
                {tableList}
                {spinner}
            </div>
        )
    }
}

const mapStateToProps = ({accountDetails: {tables, loading}}) => {
    return {tables, loading}
}

const mapDispatchToProps = (dispatch, {service}) => {
    return {
        fetchAccountDetails: fetchAccountDetails(service, dispatch)
    }
}

export default compose(
    withService(),
    connect(mapStateToProps,mapDispatchToProps)
)(AccountDetailsPage)
