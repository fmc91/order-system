import React, { useContext, useMemo, useState } from "react";
import Modal from "./Modal";
import InputGroup from "./forms/InputGroup";
import FormContext from "./forms/form-context";
import ProductsContext from "../contexts/products-context";
import { InputContextProvider } from "./forms/input-context";
import { NumberConverter } from "../value-conversion";
import { CompositeValidationRule, RangeValidationRule, RequiredValidationRule } from "../validation";
import classList from "../class-list";

import layout from "../styles/layout.module.css";
import button from "../styles/button.module.css";

export default function EditProductModal(props) {

    const formCtx = useContext(FormContext);
    const productsContext = useContext(ProductsContext);

    const [initialValues,] = useState(productsContext.products.find(p => p.productId === props.productId));

    function handleSubmit() {
        formCtx.onSubmit();
        props.onDismiss();
    }

    const requiredRule = useMemo(() => new RequiredValidationRule(), []);
    const minPriceRule = useMemo(() => new RangeValidationRule(0.01), []);
    const priceRule = useMemo(() => new CompositeValidationRule([requiredRule, minPriceRule]));

    return (
        <Modal header="Edit Product">
            <div className={classList([layout.container, layout.rowGapMedium])}>
                <div className={classList([layout.row, layout.itemGapLarge])}>
                    <div className={layout.item}>
                        <InputContextProvider
                            propertyName="name"
                            initialValue={initialValues.name}
                            validation={requiredRule}>
                            <InputGroup
                                label="Name" type="text"
                                validationMessage="Please enter a name."/>
                        </InputContextProvider>
                    </div>
                    <div className={layout.item}>
                        <InputContextProvider
                            propertyName="price"
                            initialValue={initialValues.price}
                            valueConverter={NumberConverter}
                            validation={priceRule}>
                            <InputGroup
                                label="Price" type="number" min={0.01} step={0.01}
                                validationMessage="Please enter a valid price."/>
                        </InputContextProvider>
                    </div>
                </div>
                <div className={layout.row}>
                    <div className={layout.item}>
                        <InputContextProvider propertyName="description" initialValue={initialValues.description}>
                            <InputGroup label="Description" type="text"/>
                        </InputContextProvider>
                    </div>
                </div>
                <div className={classList([layout.autoDockContainer, layout.dockItemsRight, layout.itemGapXSmall])}>
                    <button
                        className={classList([button.button, button.buttonAccept])}
                        onClick={handleSubmit}
                        disabled={!formCtx.valid}>
                        OK
                    </button>
                    <button
                        className={classList([button.button, button.buttonPrimary])}
                        onClick={props.onDismiss}>
                        Cancel
                    </button>
                </div>
            </div>
        </Modal>
    );
}