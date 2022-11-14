import React, {Component} from 'react';
import {Container, Row, Col} from 'react-bootstrap';
import Cookies from 'js-cookie';
import $ from 'jquery';
import Config from "../General/Config";

import Header from "../General/Header/Header";
import Footer from "../General/Footer/Footer";

import "../General/General.css";

class UserHomePage extends Component {
    async componentDidMount() {
        let uID = Cookies.get("uID");
        let freshLogin = Cookies.get("newLogin");

        if(uID === undefined)
        {
            window.location.replace('/');
        }

        if(freshLogin !== "true")
        {
            const delay = ms => new Promise(res => setTimeout(res, ms));

            await delay(3000);
            $.ajax({
                type: "POST",
                url: Config.apiUrl + "message/user",
                contentType: "application/json",
                data: JSON.stringify({
                    'userID': uID,
                    'heading': "Welkom terug!",
                    'content': "Leuk dat je er weer bent!",
                }),
            }).done(function (r) {
                Cookies.set('newLogin', "true"); 
            }).fail(function (e) {
                console.log(e.responseText);
            })
        }
    }

    render() {
        return (
            <>
            <Container>
                <Header/>
                <Row className={"headerSpacing"}>
                    <Col>1 of 3</Col>
                    <Col>Userhome</Col>
                    <Col>3 of 3</Col>
                </Row>
            </Container>
            <Footer/>
            </>
        );
    }
}
export default UserHomePage