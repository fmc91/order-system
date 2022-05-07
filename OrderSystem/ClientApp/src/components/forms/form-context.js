import React, { useState, useCallback } from "react";

const FormContext = React.createContext({
    value: {},
    setProperty: (propertyName, propertyValue) => {},
    cleanState: true,
    setCleanState: cleanState => {},
    valid: false,
    hasValidationError: propertyName => {},
    addValidationError: propertyName => {},
    removeValidationError: propertyName => {},
    onSubmit: () => {}
});

export default FormContext;

export function FormContextProvider(props) {

    const [value, setValue] = useState({});
    const [cleanState, setCleanState] = useState(true);
    const [validationErrors, setValidationErrors] = useState([]);

    const setProperty = useCallback((propertyName, propertyValue) =>
    {
        if (value[propertyName] !== propertyValue)
            setValue(prev => ({ ...prev, [propertyName]: propertyValue }));
    }, [value]);

    const hasValidationError = useCallback(propertyName => validationErrors.includes(propertyName), [validationErrors]);
    
    const addValidationError = useCallback(propertyName =>
    {
       if (!validationErrors.includes(propertyName))
            setValidationErrors(prev => [...prev, propertyName]);
    }, [validationErrors]);

    const removeValidationError = useCallback(propertyName =>
    {
        if (validationErrors.includes(propertyName))
        {
            setValidationErrors(prev =>
            {
                const newErrors = [...prev];
                newErrors.splice(validationErrors.indexOf(propertyName), 1);
                return newErrors;
            });
        }
    }, [validationErrors]);

    const handleSubmit = useCallback(() =>
    {
        if (props.onSubmit)
            props.onSubmit(value);
    }, [value]);

    const ctxValue = {
        value: value,
        setProperty: setProperty,
        cleanState: cleanState,
        setCleanState: setCleanState,
        valid: validationErrors.length === 0,
        hasValidationError: hasValidationError,
        addValidationError: addValidationError,
        removeValidationError: removeValidationError,
        onSubmit: handleSubmit
    };

    return <FormContext.Provider value={ctxValue}>{props.children}</FormContext.Provider>;
}