import * as React from 'react';
import {Component} from 'react';
import {Row, Col, Button} from 'react-bootstrap';

import "./Global.css";

class Global extends Component{
    constructor(props : any) {
        super(props);

        this.buttonClick =this.buttonClick.bind(this);
      }

      buttonClick() {
        window.location.href = "/how-does-it-work"
      }


    render(){
        return( 
            <Row className="global-info">
                <Col className="global-info-textbox">   
                    <Row className="spacing">
                        <Col className="global-info-text-right"></Col>
                        <Col className="global-info-text-left">
                            <span className="global-info-text-header">Zo makkelijk werkt het</span>
                        </Col>     
                    </Row>

                    <Row className="spacing">
                        <Col className="global-info-text-right">
                            <span>Stap 1</span>
                        </Col>
                        <Col className="global-info-text-left">
                            <span>Vul uw gegevens in, kies een ophaal- en aflevermoment, bekijk de prijs en betaal.</span>
                        </Col>
                    </Row>

                    <Row className="spacing">
                        <Col className="global-info-text-right">
                            <span>Stap 2</span>
                        </Col>
                        <Col className="global-info-text-left">
                            <span>Je hoort welke professionele koerier er komt.</span>
                        </Col>
                    </Row>
                    <Row className="spacing">
                        <Col className="global-info-text-right">
                            <span>Stap 3</span>
                        </Col>
                        <Col className="global-info-text-left">
                            <span>De koerier komt in actie!</span>
                        </Col>
                    </Row>
                    <Row className="spacing">
                        <Col className="global-info-text-right"></Col>
                        <Col className="global-info-text-left spacing">
                            <Button id="howDoesItWorkButton" className="btn btn-dark btn-lg btn-block btn btn-primary green" onClick={this.buttonClick}>Lees meer</Button>
                        </Col>
                    </Row>
                </Col>
                <Col className="global-info-image"></Col>
            </Row>
        );
    }
}
export default Global;