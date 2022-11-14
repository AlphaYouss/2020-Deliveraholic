import * as React from 'react';
import {Component} from 'react';

import "./WhatIsIt.css";

class WhatIsIt extends Component{
    render(){
        return( 
            <div className="title-box">
                <h1 className="page-title">Jouw transport, zo geregeld</h1>
                <span className="page-sub-title">Voordeliger en makkelijker dan zelf een busje huren</span>
            </div>
        );
    }
}
export default WhatIsIt;