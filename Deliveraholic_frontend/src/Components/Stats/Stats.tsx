import * as React from 'react';
import {Component} from 'react';
import {Row, Col} from 'react-bootstrap';

import Clock from "../../Images/Stats/clock.png";
import Delivery from "../../Images/Stats/delivery.png";
import Shield from "../../Images/Stats/shield.png";
import SpeedOMeter from "../../Images/Stats/speedometer.png";

import "./Stats.css";

class Stats extends Component{
    render(){
        return( 
            <Row className="stats">
                <Col className="box">
                    <Row>
                        <img src={SpeedOMeter} className="icon" alt="speedometer"/>
                    </Row>
                    <Row className="stats-text">
                        <p>Snel en gemakkelijk spullen halen en brengen</p>
                    </Row>
                </Col>

                <Col className="box">
                    <Row>
                        <img src={Delivery} className="icon" alt="delivery"/>
                    </Row>
                    <Row className="stats-text">
                        <p>500+ KvK geregistreerde koeriers</p>
                    </Row>
                </Col>

                <Col className="box">
                    <Row>
                        <img src={Shield} className="icon" alt="shield"/>
                    </Row>
                    <Row className="stats-text">                     
                        <p>Onderweg verzekerd tot €500</p>
                    </Row>
                </Col>

                <Col className="box">
                    <Row>
                        <img src={Clock} className="icon" alt="clock"/>
                    </Row>
                    <Row className="stats-text">
                        <p>Ophalen en bezorgen wanneer u het wilt</p>
                    </Row>
                </Col>
            </Row>
        );
    }
}
export default Stats;