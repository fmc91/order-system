import React, { useContext } from "react";
import InputContext from "./input-context";

import styles from "./InputGroup.module.css";

export default function InputGroup(props) {

    var ctx = useContext(InputContext);

    const validationMessage = !ctx.valid && ctx.touched &&
        <p className={styles.validationMessage}>
            {props.validationMessage ?? "Invalid input"}
        </p>;

    return (
        <div className={styles.inputGroup}>
            <label>{props.label}</label>
            <props.renderInput key={props.inputKey}/>
            {validationMessage}
        </div>
    );
}