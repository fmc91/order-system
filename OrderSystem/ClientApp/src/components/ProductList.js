import React from "react";
import ProductCard from "./ProductCard";

import styles from "./ProductList.module.css";

export default function ProductList(props) {

    return (
        <div className={styles.listContainer}>
            {props.products.map(p => <ProductCard key={p.productId} product={p}/>)}
        </div>
    );
}