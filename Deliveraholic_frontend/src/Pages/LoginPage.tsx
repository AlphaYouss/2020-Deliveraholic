import React, {Component} from 'react';
import {Container} from 'react-bootstrap';
import Cookies from 'js-cookie';

import Login from "../Components/Forms/Login/Login";

import "../General/General.css";

class LoginPage extends Component {
    async componentDidMount() {
        let uID = Cookies.get("uID");

        if(uID !== undefined)
        {
            window.location.replace('/user/home');
        }
    }

    render() {
        return (
            <Container>
                <Login/>
            </Container>
        );
    }
}
export default LoginPage