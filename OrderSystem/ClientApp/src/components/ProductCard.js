import React, { useMemo } from "react";

import commonStyles from "./common.module.css";
import layout from "./layout.module.css";
import styles from "./ProductCard.module.css";

export default function ProductCard(props) {

    const priceFormat = useMemo(() => new Intl.NumberFormat("en-GB", { style: "currency", currency: "GBP" }), []);

    const price = priceFormat.format(props.product.price);

    return (
        <div className={commonStyles.card + " " + styles.listItem}>
            <div className={layout.dockContainer + " " + layout.horizontalDockContainer}>
                <div className={styles.productName}>
                    {props.product.name}
                </div>
                <div className={styles.productSize + " " + layout.dockItem}>
                    {props.product.size}
                </div>
            </div>

            <div className={layout.dockContainer + " " + layout.horizontalDockContainer}>
                <div>
                    <div className={styles.category}>{props.product.categoryName}</div>
                    <div className={styles.description}>{props.product.description}</div>
                </div>
                <div className={styles.price + " " + layout.dockItem}>{price}</div>
            </div>
        </div>
    );
}