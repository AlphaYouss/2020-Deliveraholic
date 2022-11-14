import * as React from 'react';
import {Component} from 'react';
import {Form, Button} from 'react-bootstrap';
import Alert from 'react-bootstrap/Alert'
import Cookies from 'js-cookie';
import $ from 'jquery';
import Config from "../../../General/Config";

import {validateEmail, validateNames, validatePassword} from "../Form.js";

import "../Form.css";

class ForgotPassword extends Component<any, any>{
    constructor(props : any) {
        super(props);
        this.state = {
            firstname: "",
            lastname: "",
            email: "",
            password: "",
            passwordRepeat: "",
            isActive: Boolean
        }

        this.firstnameChange =      this.firstnameChange.bind(this);
        this.lastnameChange =       this.lastnameChange.bind(this);
        this.emailChange =          this.emailChange.bind(this);
        this.passwordChange =       this.passwordChange.bind(this);
        this.passwordRepeatChange = this.passwordRepeatChange.bind(this);
        this.handleSubmit =         this.handleSubmit.bind(this);
      }

      async componentDidMount() {
        let uID = Cookies.get("uID");

        if(uID !== undefined)
        {
            window.location.replace('/user/home');
        }
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

      passwordChange(event : any) {
        this.setState({password: event.target.value});
      }

      passwordRepeatChange(event : any) {
        this.setState({passwordRepeat: event.target.value});
      }

      handleSubmit() {
        $('.errorbox').css("display", "none");
        $('.forgotPasswordButton').text("Loading...");

        if(!validateNames(this.state.firstname)){
            $('.forgotPasswordButton').text("Verander wachtwoord");
  
            $('#errormessage').text("Vul een geldige voornaam in.");
            $('.errorbox').css("display", "block");
          }
        else if(!validateNames(this.state.lastname))
          {
            $('.forgotPasswordButton').text("Verander wachtwoord");
            
            $('#errormessage').text("Vul een geldige achternaam in.");
            $('.errorbox').css("display", "block");
          }
        else if(!validateEmail(this.state.email))
        {
          $('.forgotPasswordButton').text("Verander wachtwoord");

          $('#errormessage').text("E-mailadres is niet geldig.");
          $('.errorbox').css("display", "block");
        }  
        else if(!validatePassword(this.state.password))
        {
          $('.forgotPasswordButton').text("Verander wachtwoord");

          $('#errormessage').text("Vul een geldig wachtwoord in.");
          $('.errorbox').css("display", "block");
        }
        else if(!validatePassword(this.state.passwordRepeat))
        {
          $('.forgotPasswordButton').text("Verander wachtwoord");

          $('#errormessage').text("Vul een geldig wachtwoord in.");
          $('.errorbox').css("display", "block");
        }
        else if(this.state.password !== this.state.passwordRepeat)
        {
          $('.forgotPasswordButton').text("Verander wachtwoord");

          $('#errormessage').text("Wachtwoorden komen niet overeen.");
          $('.errorbox').css("display", "block");
        }
        else{
            this.changePassword();
        }
      }

      changePassword()
      {
        if(this.state.isActive !== true)
        {
            this.setState({isActive: true});

            $.ajax({
                type: "PUT",
                url: Config.apiUrl + "account/forgot-password",
                data: {
                    'firstname':        this.state.firstname,
                    'lastname':         this.state.lastname,
                    'email':            this.state.email,
                    'password':         this.state.password,
                    'passwordRepeat':   this.state.passwordRepeat
                },
            }).done((r) => {
                window.location.replace('/login');
            }).fail((e) => {
                if(e.responseText === null || e.responseText === undefined)
                {
                    $('.forgotPasswordButton').text("Verander wachtwoord");
    
                    $('#errormessage').text("Er is een fout opgetreden, probeer het opnieuw. Indien dit niet lukt, neem contact met ons op!");
                }
                else{
                    $('.forgotPasswordButton').text("Verander wachtwoord");
                    
                    $('#errormessage').text(e.responseText);
                }
                this.setState({isActive: false});
                
                $('.errorbox').css("display", "block");
            });
        }
      }

    render(){
        return(
            <div className="outer">
                <Form className="inner">
                    <h1>Wachtwoord vergeten</h1>

                    <Form.Group>
                        <Alert variant="danger errorbox">
                            <Alert.Heading>Foutmelding:</Alert.Heading>
                            <span id="errormessage"></span>
                        </Alert>
                    </Form.Group>

                    <Form.Group>
                        <Form.Label>Voornaam</Form.Label>
                        <Form.Control id="firstname" type="text" className="form-control" placeholder="Voer voornaam in" value={this.state.firstname.toString()} onChange={this.firstnameChange} autoComplete="given-name" required />
                    </Form.Group>

                    <Form.Group>
                        <Form.Label>Achternaam</Form.Label>
                        <Form.Control id="lastname" type="text" className="form-control" placeholder="Voer achternaam in" value={this.state.lastname.toString()} onChange={this.lastnameChange} autoComplete="family-name"required />
                    </Form.Group>

                    <Form.Group>
                        <Form.Label>Email</Form.Label>
                        <Form.Control id="email" type="email" className="form-control" placeholder="Voer email in" value={this.state.email.toString()} onChange={this.emailChange} autoComplete="email" required />
                    </Form.Group>

                    <Form.Group>
                        <Form.Label>Wachtwoord</Form.Label>
                        <Form.Control id="password" type="password" className="form-control" placeholder="***********" value={this.state.password.toString()} onChange={this.passwordChange} autoComplete="new-password" required />
                    </Form.Group>

                    <Form.Group>
                        <Form.Label>Wachtwoord herhalen</Form.Label>
                        <Form.Control id="passwordRepeat" type="password" className="form-control" placeholder="***********" value={this.state.passwordRepeat.toString()} onChange={this.passwordRepeatChange} autoComplete="new-password" required />
                    </Form.Group>

                    <Form.Group className="links">
                    <Form.Text className="login link">
                            <a href="/login">Ik heb al een account.</a>
                        </Form.Text>
                        <Form.Text className="register link">
                            <a href="/register">Maak hier een account aan!</a>
                        </Form.Text>
                    </Form.Group>

                    <Button id="forgotPasswordButton" className="btn btn-dark btn-lg btn-block loginbutton" onClick={this.handleSubmit}>
                        Verander wachtwoord
                    </Button>
                </Form>
            </div>
        );
    }
}
export default ForgotPassword;