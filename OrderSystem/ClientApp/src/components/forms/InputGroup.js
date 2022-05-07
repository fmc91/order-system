import React, { useContext } from "react";
import Input from "./Input.js";
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
            <Input
                type={props.type}
                min={props.min ?? undefined}
                max={props.max ?? undefined}
                step={props.step ?? undefined}/>
            {validationMessage}
        </div>
    );
}