import React, { useContext } from "react";
import InputContext from "./input-context";

import styles from "./Input.module.css";

export default function Input(props) {

    const ctx = useContext(InputContext);

    return (
        <input
            className={
                styles.input +
                (!ctx.valid ? " " + styles.invalid : "") +
                (ctx.touched ? " " + styles.touched : "")}
            type={props.type ?? "text"}
            min={props.min ?? undefined}
            max={props.max ?? undefined}
            step={props.step ?? undefined}
            value={ctx.inputValue}
            onChange={ev => ctx.handleInputChange(ev.target.value)}
            onBlur={ctx.handleInputLostFocus}/>
    );
}