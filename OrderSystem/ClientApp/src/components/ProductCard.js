import React, { useMemo } from "react";
import classList from "../class-list";

import common from "../styles/common.module.css";
import layout from "../styles/layout.module.css";
import button from "../styles/button.module.css";
import styles from "./ProductCard.module.css";

export default function ProductCard(props) {

    const priceFormat = useMemo(() => new Intl.NumberFormat("en-GB", { style: "currency", currency: "GBP" }), []);

    const price = priceFormat.format(props.product.price);

    return (
        <div className={classList([common.card, styles.listItem])}>
            <div className={classList([layout.dockContainer, layout.horizontalDockContainer])}>
                <div>
                    <div className={styles.productName}>
                        {props.product.name}
                    </div>
                    <div className={styles.category}>
                        {props.product.categoryName}
                    </div>
                    <div className={styles.description}>
                        {props.product.description}
                    </div>
                </div>
                <div className={layout.dockItem}>
                    <div className={styles.productSize}>
                        {props.product.size.length}mm x {props.product.size.width}mm x {props.product.size.height}mm
                    </div>
                    <div className={styles.productWeight}>
                        {props.product.weight}kg
                    </div>
                    <div className={styles.price}>
                        {price}
                    </div>
                </div>
            </div>

            <div className={classList([layout.autoDockContainer, layout.dockItemsRight, styles.buttonStrip])}>
                <button
                    className={classList([button.button, button.buttonDanger, layout.dockItem])}
                    onClick={() => props.onDeleteButtonClick(props.product.productId)}>
                    Delete
                </button>
                <button
                    className={classList([button.button, button.buttonPrimary, layout.dockItem])}
                    onClick={() => props.onEditButtonClick(props.product.productId)}>
                    Edit
                </button>
            </div>
        </div>
    );
}