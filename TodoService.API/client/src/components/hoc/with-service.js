import React from 'react'
import {ServiceConsumer} from '../todo-service-context'

const withService = () => (Wrapped) => {
    
    return(props) => {
        return(
            <ServiceConsumer>
                {
                    (todoService) => {
                        return (
                            <Wrapped {...props} 
                                service = {todoService}/>
                        )
                    }
                }
            </ServiceConsumer>
        )
    }
}

export default withService