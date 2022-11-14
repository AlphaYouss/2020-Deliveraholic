import * as React from 'react';
import {Component} from 'react';

import "./Banner.css";

import Banner from "../../Images/banner.jpg";

class Slider extends Component{
    render(){
        return( 
            <img src={Banner} className="banner" alt="banner"/>
        );
    }
}
export default Slider;