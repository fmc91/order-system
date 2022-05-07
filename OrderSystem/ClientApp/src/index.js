import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import * as serviceWorkerRegistration from './serviceWorkerRegistration';
import reportWebVitals from './reportWebVitals';
import { ProductsContextProvider } from './contexts/products-context';

const rootElement = document.getElementById('root');

ReactDOM.render(
    <ProductsContextProvider page={0} itemsPerPage={20}>
        <App />
    </ProductsContextProvider>,
    rootElement);

serviceWorkerRegistration.unregister();
reportWebVitals();
