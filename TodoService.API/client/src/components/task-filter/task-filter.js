import React from 'react'
import './task-filter.css'
import {filterChanged} from '../../actions/selected-table'
import { connect } from 'react-redux';

const filterButtons = [
    { name: 'all', label: 'All' },
    { name: 'active', label: 'Active' },
    { name: 'done', label: 'Done' }
  ];

const TaskFilter = ({filter, onFilterChange}) => {

    const buttons = filterButtons.map(({name, label}) => {
      const isActive = name === filter;
      const classNames = 'btn ' + (isActive ? 'btn-info' : 'btn-outline-secondary');
  
      return (
        <button key={name}
                type="button"
                onClick={() => onFilterChange(name)}
                className={classNames}>{label}</button>
      );
    });
  
    return (
      <div className="btn-group">
        { buttons }
      </div>
    );
};

const mapStateToProps = ({table:{filter}}) => {
    return{filter}
}

const mapDispatchToProps = {
    onFilterChange: filterChanged
}

export default connect(mapStateToProps,mapDispatchToProps)(TaskFilter);