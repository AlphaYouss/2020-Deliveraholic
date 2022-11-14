import React, {Component} from 'react';
import {Container} from 'react-bootstrap';
import Cookies from 'js-cookie';

import ForgotPassword from "../Components/Forms/ForgotPassword/ForgotPassword";

import "../General/General.css";

class ForgotPasswordPage extends Component {
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
                <ForgotPassword/>
            </Container>
        );
    }
}
export default ForgotPasswordPage