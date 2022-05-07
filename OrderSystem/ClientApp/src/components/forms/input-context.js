import React, { useContext, useCallback, useState, useEffect } from "react";
import FormContext from "./form-context";

const InputContext = React.createContext({
    propertyName: "",
    inputValue: "",
    modelValue: null,
    handleInputChange: value => {},
    handleInputLostFocus: () => {},
    valid: false,
    touched: false,
    setTouched: touched => {}
});

export default InputContext;

export function InputContextProvider(props) {

    const formCtx = useContext(FormContext);

    const [valid, setValid] = useState(!props.validation);
    const [touched, setTouched] = useState(false);

    useEffect(() =>
    {
        const inputValue = props.initialValue ?? "";

        modelValue =
            props.valueConverter?.convertToModelType ?
            props.valueConverter.convertToModelType(inputValue) :
            inputValue;

        formCtx.setProperty(props.propertyName, modelValue);
    }, []);

    const handleInputChange = useCallback(newValue =>
    {
        formCtx.setCleanState(false);

        const convertedValue =
            props.valueConverter?.convertToModelType ?
            props.valueConverter.convertToModelType(newValue) :
            newValue;

        formCtx.setProperty(props.propertyName, convertedValue);

        if (props.validation)
        {
            const isValid = props.validation.validate(convertedValue);
            setValid(isValid);

            if (isValid)
                formCtx.removeValidationError(props.propertyName);
            else
                formCtx.addValidationError(props.propertyName);
        }

    }, [
        props.valueConverter, props.validation, props.propertyName,
        formCtx.setProperty, formCtx.setCleanState, formCtx.addValidationError, formCtx.removeValidationError
    ]);

    const handleInputLostFocus = useCallback(() =>
    {
        if (!touched) setTouched(true);
    }, [touched]);

    if (formCtx.cleanState && touched)
        setTouched(false);

    let modelValue = formCtx.value[props.propertyName];

    const inputValue =
        !modelValue ? "" :
        props.valueConverter?.convertToInput ?
            props.valueConverter.convertToInput(modelValue) :
            String(modelValue);

    const ctxValue = {
        propertyName: props.propertyName,
        inputValue: inputValue,
        modelValue: modelValue,
        handleInputChange: handleInputChange,
        handleInputLostFocus: handleInputLostFocus,
        valid: valid,
        touched: touched,
        setTouched: setTouched
    };

    return <InputContext.Provider value={ctxValue}>{props.children}</InputContext.Provider>;
}