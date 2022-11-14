import * as React from 'react';
import {Component} from 'react';

import "./MessageBox.css";

interface props{
    heading: "",
    content: ""
}

class MessageBox extends Component<props>{
    render(){
        return( 
            <div className="user-alert">
                <div className="header">
                    {this.props.heading}
                </div>
                <div className="context">
                    {this.props.content}
                </div>
            </div>
        );
    }
}
export default MessageBox;