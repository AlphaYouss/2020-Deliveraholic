import * as React from 'react';
import {Component} from 'react';
import {Form, Button} from 'react-bootstrap';
import Alert from 'react-bootstrap/Alert'
import $ from 'jquery';
import Cookies from 'js-cookie';
import Config from "../../../General/Config";

import {validateEmail, validatePassword} from "../Form.js";

import "../Form.css";

class Login extends Component<any, any>{
    constructor(props : any) {
        super(props);
        this.state = {
            email: "",
            password: "",
            isActive: Boolean
        }
    
        this.emailChange =      this.emailChange.bind(this);
        this.passwordChange =   this.passwordChange.bind(this);
        this.handleSubmit =     this.handleSubmit.bind(this);
        this.getUID =           this.getUID.bind(this);
      }

      emailChange(event : any) {
        this.setState({email: event.target.value});
      }

      passwordChange(event : any) {
        this.setState({password: event.target.value});
      }

      handleSubmit() {
        $('.errorbox').css("display", "none");
        $('.loginbutton').text("Loading...");

        if(!validateEmail(this.state.email))
        {
            // Email validation failed.

            $('.loginbutton').text("Inloggen");

            $('#errormessage').text("E-mailadres is niet geldig.");
            $('.errorbox').css("display", "block");
        }
        else if(!validatePassword(this.state.password))
        {
            // Password validation failed.
            
            $('.loginbutton').text("Inloggen");

            $('#errormessage').text("Vul een geldig wachtwoord in.");
            $('.errorbox').css("display", "block");
        }
        else{
            this.login();
        }
      }

      login()
      {
        if(this.state.isActive !== true)
        {
            this.setState({isActive: true});

            $.ajax({
                type: "POST",
                url: Config.apiUrl + "account/login",
                data: {
                    'email':    this.state.email,
                    'password': this.state.password
                },
            }).done((r) => {
                this.getUID()
            }).fail( (e) => {
                if(e.responseText === null || e.responseText === undefined)
                {
                    $('.loginbutton').text("Inloggen");
    
                    $('#errormessage').text("Er is een fout opgetreden, probeer het opnieuw. Indien dit niet lukt, neem contact met ons op!");
                }
                else{
                    $('.loginbutton').text("Inloggen");
                    
                    $('#errormessage').text(e.responseText);
                }
                this.setState({isActive: false});
                
                $('.errorbox').css("display", "block");
            });
        }
      }

      getUID() {
        $.ajax({
            type: "GET",
            url: Config.apiUrl + "account/byemail/" + this.state.email.toString(),
            data: {
                'email': this.state.email
            },
        }).done(function (r) {
            Cookies.set('uID', r.accountID);         
            window.location.replace('/user/home');
        }).fail((e) => {
            this.setState({isActive: false});

            $('#errormessage').text(e.responseText);
        });
      }

    render(){
        return(
            <div className="outer">
                <Form className="inner">
                    <h1>Inloggen</h1>

                    <Form.Group>
                        <Alert variant="danger errorbox">
                            <Alert.Heading>Foutmelding:</Alert.Heading>
                            <span id="errormessage"></span>
                        </Alert>
                    </Form.Group>

                    <Form.Group>
                        <Form.Label>Email</Form.Label>
                        <Form.Control id="email" type="email" className="form-control" placeholder="Voer email in" value={this.state.email.toString()} onChange={this.emailChange} autoComplete="email" required />
                    </Form.Group>

                    <Form.Group>
                        <Form.Label>Wachtwoord</Form.Label>
                        <Form.Control id="password" type="password" className="form-control" placeholder="Voer wachtwoord in" value={this.state.password.toString()} onChange={this.passwordChange} autoComplete="current-password" required />
                    </Form.Group>

                    <Form.Group className="links">
                        <Form.Text className="register link">
                            <a href="/register">Maak hier een account aan!</a>
                        </Form.Text>
                        <Form.Text className="forgot-password link">
                            <a href="/forgot-password">Wachtwoord vergeten?</a>
                        </Form.Text>
                    </Form.Group>

                    <Button id="loginButton" className="btn btn-dark btn-lg btn-block loginbutton" onClick={this.handleSubmit}>
                        Inloggen
                    </Button>
                </Form>
            </div>
        );
    }
}
export default Login;