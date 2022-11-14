import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { HubConnectionBuilder } from '@microsoft/signalr';
import Cookies from 'js-cookie';
import Config from "../src/General/Config";

import MessageBox from '../src/Components/MessageBox/MessageBox';

var connection = new HubConnectionBuilder().withUrl(Config.backendUrl + "/UserMessageHub?userID=" + Cookies.get("uID")).build();

connection.on("sendToUser", (heading, content) => {
    ReactDOM.unmountComponentAtNode(document.getElementById('alert'));
    ReactDOM.render(<MessageBox heading={heading} content={content}/>, document.getElementById('alert'))
});

connection.start().catch(function (err) {
    return console.error(err.toString());
}).then(function () {
    connection.invoke('GetConnectionID').then(function (connectionID) {
        document.getElementById('signalRConnectionID').innerHTML = connectionID;
    })});

ReactDOM.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>,
  document.getElementById('root')
);

reportWebVitals();