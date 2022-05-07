import React, { useState, useCallback } from "react";

const ProductsContext = React.createContext({
    products: [],
    loadProducts: () => {},
    createProduct: product => {},
    updateProduct: product => {},
    removeProduct: productId => {}
});

export default ProductsContext;

export function ProductsContextProvider(props) {

    const [products, setProducts] = useState([]);

    const loadProducts = useCallback(async () =>
    {
        const url = `https://localhost:7133/api/product?page=${props.page}&itemsPerPage=${props.itemsPerPage}`;
        const response = await fetch(url);

        if (!response.ok)
        {
            console.error(`Received response code ${response.status} attempting to get products.`);
            return;
        }

        const content = await response.json();
        setProducts(content);
    }, [props.page, props.itemsPerPage]);

    const createProduct = useCallback(async product =>
    {
        const url = "https://localhost:7133/api/product";

        const response = await fetch(url, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(product)
        });

        if (!response.ok)
        {
            console.error(`Received response code ${response.status} attempting to create product.`);
            return;
        }

        await loadProducts();
    }, [loadProducts]);

    const updateProduct = useCallback(async (product) =>
    {
        const url = "https://localhost:7133/api/product";

        const response = await fetch(url, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(product)
        });

        if (!response.ok)
        {
            console.error(`Received response code ${response.status} attempting to create product.`);
            return;
        }

        const index = products.findIndex(p => p.productId === product.productId);

        if (index !== -1)
        {
            setProducts(prev =>
            {
                const newProducts = [...prev];
                newProducts[index] = product;
                return newProducts;
            });
        }

    }, [products]);

    const removeProduct = useCallback(async product =>
    {
        const url = "https://localhost:7133/api/product";

        const response = await fetch(url, {
            method: "DELETE",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(product)
        });

        if (!response.ok)
        {
            console.error(`Received response code ${response.status} attempting to create product.`);
            return;
        }

        const index = products.findIndex(p => p.productId === product.productId);

        if (index !== -1)
            await loadProducts();

    }, [products, loadProducts]);

    const value = {
        products: products,
        loadProducts: loadProducts,
        createProduct: createProduct,
        updateProduct: updateProduct,
        removeProduct: removeProduct
    };

    return <ProductsContext.Provider value={value}>{props.children}</ProductsContext.Provider>;
}