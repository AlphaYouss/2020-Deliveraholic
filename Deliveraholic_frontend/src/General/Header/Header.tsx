import * as React from 'react'
import {Component} from 'react';
import {Row} from 'react-bootstrap';
import Cookies from 'js-cookie';

class Header extends Component{
    constructor(props : any) {
        super(props);

        this.handleLogout = this.handleLogout.bind(this);
      }

    handleLogout() {
        Cookies.remove("uID");
        Cookies.remove("newLogin");
        
        window.location.replace("/");
    }

    render(){
        return(
            <Row className="header-color">
                <div>
                    <span className="title">
                        Deliveraholic
                    </span>
                </div>

                <input id="burger" type="checkbox" />
                <label id="menu" htmlFor="burger">
                    <span></span>
                    <span></span>
                    <span></span>
                </label>

                <nav>    
                    <ul>
                        {(() => {
                                    let uID = Cookies.get("uID");
                            
                                    if(uID === undefined)
                                    {
                                        return(
                                            <>
                                                <li className="hidden"></li>
                                                <li><a href="/">Home</a></li>
                                                <li><a href="/how-does-it-work">Hoe werkt het?</a></li>
                                                <li><a href="/login">Inloggen</a></li>
                                                <li><a href="/register">Registreren</a></li>
                                            </>
                                        )
                                    }
                                    else{
                                        return(
                                            <>
                                                <li className="hidden"></li>
                                                <li><a href="/">Home</a></li>
                                                <li><a href="/how-does-it-work">Hoe werkt het?</a></li>
                                                <li><a href="/user/home">Mijn account</a></li>
                                                <li><a id="logout" href="#logout" onClick={this.handleLogout}>Uitloggen</a></li>
                                            </>
                                        )
                                    }
                        })()}
                    </ul>  
                </nav>
            </Row>
        );
    }
}
export default Header;