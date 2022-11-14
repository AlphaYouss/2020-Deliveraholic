import * as React from 'react';
import {Component} from 'react';
import {Form, Button} from 'react-bootstrap';
import Alert from 'react-bootstrap/Alert'
import $ from 'jquery';
import Config from "../../../General/Config";

import {validateNames, validateEmail, validatePhonenumber, validatePassword} from "../Form.js";

import "../Form.css";

class Login extends Component<any, any>{
    constructor(props : any) {
        super(props);
        this.state = {
            firstname: "",
            lastname: "",
            email: "",
            phonenumber: "",
            password: "",
            isActive: Boolean
        }
    
        this.firstnameChange =    this.firstnameChange.bind(this);
        this.lastnameChange =     this.lastnameChange.bind(this);
        this.emailChange =        this.emailChange.bind(this);
        this.phonenumberChange =  this.phonenumberChange.bind(this);
        this.passwordChange =     this.passwordChange.bind(this);
        this.handleSubmit =       this.handleSubmit.bind(this);
      }

      firstnameChange(event : any) {
        this.setState({firstname: event.target.value});
      }

      lastnameChange(event : any) {
        this.setState({lastname: event.target.value});
      }

      emailChange(event : any) {
        this.setState({email: event.target.value});
      }

      phonenumberChange(event : any) {
        this.setState({phonenumber: event.target.value});
      }

      passwordChange(event : any) {
        this.setState({password: event.target.value});
      }
      
      handleSubmit() {
        $('.errorbox').css("display", "none");
        $('.registerbutton').text("Loading...");

        if(!validateNames(this.state.firstname)){
          $('.registerbutton').text("Maak mijn account aan!");

          $('#errormessage').text("Vul een geldige voornaam in.");
          $('.errorbox').css("display", "block");
        }
        else if(!validateNames(this.state.lastname))
        {
          $('.registerbutton').text("Maak mijn account aan!");
          
          $('#errormessage').text("Vul een geldige achternaam in.");
          $('.errorbox').css("display", "block");
        }
        else if(!validateEmail(this.state.email))
        {
          $('.registerbutton').text("Maak mijn account aan!");

          $('#errormessage').text("E-mailadres is niet geldig.");
          $('.errorbox').css("display", "block");
        }
        else if(!validatePhonenumber(this.state.phonenumber))
        {
          $('.registerbutton').text("Maak mijn account aan!");

          $('#errormessage').text("Vul een geldige telefoonnummer in.");
          $('.errorbox').css("display", "block");
        }
        else if(!validatePassword(this.state.password))
        {
          $('.registerbutton').text("Maak mijn account aan!");

          $('#errormessage').text("Vul een geldig wachtwoord in.");
          $('.errorbox').css("display", "block");
        }
        else{
            this.register();
        }
      }

      register(){
        if(this.state.isActive !== true)
        {
          this.setState({isActive: true});
          
          $.ajax({
            type: "POST",
            url: Config.apiUrl + "account/register/user",
            contentType: "application/json",
            data: JSON.stringify({
                'firstName':    this.state.firstname,
                'lastName':     this.state.lastname,
                'email':        this.state.email,
                'phoneNumber':  this.state.phonenumber,
                'passwordHash': this.state.password
            }),
        }).done(function (r) {
            window.location.replace('/login');
        }).fail((e) => {
            if(e.responseText === null || e.responseText === undefined)
            {
              $('.registerbutton').text("Maak mijn account aan!");

              $('#errormessage').text("Er is een fout opgetreden, probeer het opnieuw. Indien dit niet lukt, neem contact met ons op!");
            }
            else{
              $('.registerbutton').text("Maak mijn account aan!");
              
              $('#errormessage').text(e.responseText);
            };
            this.setState({isActive: false});

            $('.errorbox').css("display", "block");
        });
        }
      }

    render(){
        return(
            <div className="outer">
                <Form className="inner">
                    <h1>Registeren</h1>

                    <Form.Group>
                        <Alert variant="danger errorbox">
                            <Alert.Heading>Foutmelding:</Alert.Heading>
                            <span id="errormessage"></span>
                        </Alert>
                    </Form.Group>

                    <Form.Group>
                        <Form.Label>Voornaam</Form.Label>
                        <Form.Control id="firstname" type="text" className="form-control" placeholder="John" value={this.state.firstname.toString()} onChange={this.firstnameChange} autoComplete="given-name" required />
                    </Form.Group>

                    <Form.Group>
                        <Form.Label>Achternaam</Form.Label>
                        <Form.Control id="lastname" type="text" className="form-control" placeholder="Doe" value={this.state.lastname.toString()} onChange={this.lastnameChange} autoComplete="family-name" required />
                    </Form.Group>

                    <Form.Group>
                        <Form.Label>Email</Form.Label>
                        <Form.Control id="email" type="email" className="form-control" placeholder="J.Doe@gmail.com" value={this.state.email.toString()} onChange={this.emailChange} autoComplete="email" required />
                    </Form.Group>

                    <Form.Group>
                        <Form.Label>Telefoonnummer</Form.Label>
                        <Form.Control id="phonenumber" type="text" className="form-control" minLength={12} maxLength={12} placeholder="+31600000000" value={this.state.phonenumber} onChange={this.phonenumberChange} autoComplete="tel" required />
                    </Form.Group>

                    <Form.Group>
                        <Form.Label>Wachtwoord</Form.Label>
                        <Form.Control id="password" type="password" className="form-control" placeholder="***********" value={this.state.password.toString()} onChange={this.passwordChange} autoComplete="new-password" required />
                    </Form.Group>

                    <Form.Group className="links">
                        <Form.Text className="login link">
                            <a href="/login">Ik heb al een account.</a>
                        </Form.Text>
                    </Form.Group>

                    <Button id="registerButton" className="btn btn-dark btn-lg btn-block registerbutton" onClick={this.handleSubmit}>Maak mijn account aan!</Button>
                </Form>
            </div>
        );
    }
}
export default Login;