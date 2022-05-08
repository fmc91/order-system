import React, { useContext } from "react";
import InputContext from "./input-context";
import classList from "../../class-list";

import styles from "./Input.module.css";

export default function Input(props) {

    const ctx = useContext(InputContext);

    const classes = classList([
        styles.input, {
            [styles.invalid]: !ctx.valid,
            [styles.touched]: ctx.touched
        }
    ]);

    return (
        <input
            className={classes}
            type={props.type ?? "text"}
            min={props.min ?? undefined}
            max={props.max ?? undefined}
            step={props.step ?? undefined}
            value={ctx.inputValue}
            onChange={ev => ctx.handleInputChange(ev.target.value)}
            onBlur={ctx.handleInputLostFocus}/>
    );
}