import React, { useContext, useMemo, useState } from "react";
import Modal from "./Modal";
import InputGroup from "./forms/InputGroup";
import FormContext from "./forms/form-context";
import ProductsContext from "../contexts/products-context";
import { InputContextProvider } from "./forms/input-context";
import { NumberConverter } from "../value-conversion";
import { RequiredValidationRule } from "../validation";

export default function EditProductModal(props) {

    const formCtx = useContext(FormContext);
    const productsContext = useContext(ProductsContext);

    const [initialValues,] = useState(productsContext.products.find(p => p.productId === props.productId));

    function handleSubmit() {
        formCtx.onSubmit();
        props.onDismiss();
    }

    //const initialValues = useMemo(() => productsContext.products.find(p => p.productId === props.productId), [productsContext.products]);

    const requiredRule = useMemo(() => new RequiredValidationRule(), []);

    return (
        <Modal header="Edit Product">
            <InputContextProvider propertyName="name" initialValue={initialValues.name} validation={requiredRule}>
                <InputGroup label="Name" type="text"
                    validationMessage="Please enter a name."/>
            </InputContextProvider>
            <InputContextProvider propertyName="description" initialValue={initialValues.description}>
                <InputGroup label="Description" type="text"/>
            </InputContextProvider>
            <InputContextProvider propertyName="price" valueConverter={NumberConverter} initialValue={initialValues.price}>
                <InputGroup label="Price" type="number" min={0.01} step={0.01}/>
            </InputContextProvider>
            <button onClick={handleSubmit} disabled={!formCtx.valid}>OK</button>
            <button onClick={props.onDismiss}>Cancel</button>
        </Modal>
    );
}