import React, {Component} from 'react';
import {Container} from 'react-bootstrap';

import Header from "../General/Header/Header";
import Footer from "../General/Footer/Footer";
import HowDoesItWork from '../Components/Info/HowDoesItWork/HowDoesItWork';

import "../General/General.css";

class HomePage extends Component {
    render() {
        return (
            <>
                <Container>
                    <Header/>
                    <HowDoesItWork/>
                </Container>
                <Footer/>
            </>
        );
    }
}
export default HomePage