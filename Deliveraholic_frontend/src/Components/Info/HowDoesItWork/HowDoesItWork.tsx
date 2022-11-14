import * as React from 'react';
import {Component} from 'react';
import {Row, Button} from 'react-bootstrap';

import Clock from "../../../Images/Stats/clock.png";
import Delivery from "../../../Images/Stats/delivery.png";
import Man from "../../../Images/Stats/man.png";

import "./HowDoesItWork.css";

class HowDoesItWork extends Component{
    render(){
        return( 
            <Row className="how-does-it-work-info">
                <div className="header">
                    <h1 className="how-does-it-work-info-header">
                        Hoe het werkt
                    </h1>
                </div>
                <div className="step">
                    <img src={Delivery} className="step-icon" alt="delivery"/>
                    <h3 className="how-does-it-work-info-step">
                        Stap 1: Plaats je transport
                    </h3>
                    <ul>
                        <li>
                            Vul op de orderpage de plaatsnamen in en ga naar de volgende stap.
                        </li>
                        <li>
                            Selecteer het type transport: vanaf een woning, een zakelijk adres, een veiling, marktplaats of winkel.
                        </li>
                        <li>
                            Vul de afmetingen van jouw voorwerp in. Bestaat deze uit meerdere delen? Vul dan van elk deel de afmetingen in.
                        </li>
                        <li>
                            Je hebt keuze uit 2 pakketten: Simpel of Extra Services. Hier kun je optioneel kiezen voor extra services, zoals hulp bij het sjouwen of een bus inclusief laadklep. Doorloop daarna alle stappen.
                        </li>
                        <li>
                            Ga door naar de betaling met PayPal, iDEAL, Creditcard of andere methodes zoals Bancontact.
                        </li>
                    </ul>
                </div>

                <div className="step">
                    <img src={Clock} className="step-icon"  alt="clock"/>
                    <h3 className="how-does-it-work-info-step">
                        Stap 2: Je ontvangt het exacte tijdvak
                    </h3>
                    <ul>
                        <li>
                            Nadat je hebt betaald, zal een professionele koerier die de route toch al rijdt jouw transport claimen. Zo maken wij samen iedere rit een stukje duurzamer!
                        </li>
                        <li>
                            Onze bezorgers zijn de best beoordeelde koeriers van Nederland. Mocht er toch wat gebeuren, zijn al onze transporten tot €500 verzekerd aan schade die onderweg ontstaat.
                        </li>
                        <li>
                            Jij ontvangt een e-mail met het tijdvak van 4 uur waarin de koerier jouw spullen komt bezorgen. Ook ontvang je de gegevens van de koerier zodat jullie elkaar op de hoogte kunnen houden.
                        </li>
                    </ul>
                </div>
    
                <div className="step">
                    <img src={Man} className="step-icon" alt="man"/>
                    <h3 className="how-does-it-work-info-step">
                        Stap 3: De koerier komt in actie
                    </h3>
                    <ul>
                        <li>
                            De koerier gaat jouw spullen ophalen en afleveren in het afgesproken tijdvak van maximaal 4 uur.
                        </li>
                        <li>
                            Bevestig na afloop het ontvangst zodra alles is bezorgd en de koerier wordt uitbetaald.
                        </li>
                        
                    </ul>
                </div>

                <a href="/login">
                    <Button className="btn btn-dark btn-lg btn-block loginbutton btn btn-primary green">Breng mij er naartoe!</Button>
                </a>
            </Row>
        );
    }
}
export default HowDoesItWork;