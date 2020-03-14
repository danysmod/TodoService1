import React from 'react';
import { Switch, Route, Redirect } from 'react-router-dom';
import { AccountDetailsPage, LoginPage, RegisterPage, TableDetailPage} from './components/pages';
import PrivateRoute from './components/hoc/private-route'

const Routes =  () => {
    return(
        <Switch>
            <Route path="/signup" exact component={RegisterPage}/>
            <Route path="/signin" exact component={LoginPage}/>
            
            <PrivateRoute path="/" exact component={AccountDetailsPage} redirectUrl={"/signin"}/>
            <PrivateRoute path="/table/:id?" exact component={TableDetailPage} redirectUrl={"/signin"}/>
        </Switch>
    )
}

export default Routes;