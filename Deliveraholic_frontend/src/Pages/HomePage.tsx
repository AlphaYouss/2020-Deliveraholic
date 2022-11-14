import React, {Component} from 'react';
import {Container} from 'react-bootstrap';

import Header from "../General/Header/Header";
import Footer from "../General/Footer/Footer";
import Banner from '../Components/Banner/Banner';
import WhatIsIt from '../Components/Info/WhatIsIt/WhatIsIt';
import Stats from '../Components/Stats/Stats';
import Global from '../Components/Info/Global/Global';

import "../General/General.css";

class HomePage extends Component {
    render() {
        return (
            <>
                <Container>
                    <Header/>
                </Container>
                <Banner/>
                <WhatIsIt/>
                <Stats/>
                <Global/>
                <Footer/>
            </>
        );
    }
}
export default HomePage