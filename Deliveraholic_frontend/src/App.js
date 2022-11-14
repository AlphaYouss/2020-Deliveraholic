import React from 'react';
import {BrowserRouter as Router, Switch, Route} from "react-router-dom";

import HomePage from "./Pages/HomePage";
import HowDoesItWorkPage from "./Pages/HowDoesItWorkPage";
import LoginPage from "./Pages/LoginPage";
import RegisterPage from "./Pages/RegisterPage";
import ForgotPassword from "./Pages/ForgotPasswordPage";

import UserHomePage from "./Pages/UserHomePage";

import 'bootstrap/dist/css/bootstrap.min.css';

function App() {
    return (
        <Router>
            <Switch>
                <Route exact path="/">
                    <HomePage/>
                </Route>
                <Route exact path="/how-does-it-work">
                    <HowDoesItWorkPage/>
                </Route>
                <Route exact path="/login">
                    <LoginPage/>
                </Route>
                <Route exact path="/register">
                    <RegisterPage/>
                </Route>
                <Route exact path="/forgot-password">
                    <ForgotPassword/>
                </Route>
                <Route exact path="/user/home">
                    <UserHomePage/>
                </Route>
            </Switch>
        </Router>
    );
}
export default App