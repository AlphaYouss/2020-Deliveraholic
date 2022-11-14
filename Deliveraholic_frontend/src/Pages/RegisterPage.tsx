import React, {Component} from 'react';
import {Container} from 'react-bootstrap';
import Cookies from 'js-cookie';

import Register from "../Components/Forms/Register/Register";

import "../General/General.css";

class RegisterPage extends Component {
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
                <Register/>
            </Container>
        );
    }
}
export default RegisterPage