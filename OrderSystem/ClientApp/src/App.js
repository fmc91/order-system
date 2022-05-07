import React, { useEffect, useState } from 'react';
import ProductList from './components/ProductList';

export default function App() {
    
    const [products, setProducts] = useState([]);

    useEffect(() =>
    {
        async function loadData()
        {
            const response = await fetch("https://localhost:7133/api/product");

            if (!response.ok)
            {
                console.error(`Received response code ${response.status} when attempting to get products.`);
                return;
            }

            var content = await response.json();
            setProducts(content);
        }

        loadData();
        
    }, []);
    
    return <ProductList products={products}/>;
}
