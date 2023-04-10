import "react-app-polyfill/ie11";
import "react-app-polyfill/stable";
import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import {Provider} from "react-redux";
import {store} from "./store";
import {BrowserRouter} from "react-router-dom";

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <React.StrictMode>
      <BrowserRouter >
          <Provider store={store}>
            <App />
          </Provider>
      </BrowserRouter>
  </React.StrictMode>
);
