import React, { useContext, useEffect } from "react";
import ProductCard from "./ProductCard";
import ProductsContext from "../contexts/products-context";

import styles from "./ProductList.module.css";

export default function ProductList(props) {

    const context = useContext(ProductsContext);

    useEffect(() => context.loadProducts(), []);

    return (
        <div className={styles.listContainer}>
            {context.products.map(p =>
                <ProductCard
                    key={p.productId}
                    product={p}
                    onEditButtonClick={props.onEditButtonClick}
                    onDeleteButtonClick={props.onDeleteButtonClick}/>)}
        </div>
    );
}