import React, { useContext } from "react";
import InputContext from "./input-context";
import classList from "../../class-list";

import styles from "./TextArea.module.css";

export default function TextArea(props) {

    const ctx = useContext(InputContext);

    const classes = classList([
        styles.textArea, {
            [styles.invalid]: !ctx.valid,
            [styles.touched]: ctx.touched
        }
    ]);

    return (
        <textarea
            className={classes}
            rows={props.rows ?? undefined}
            cols={props.cols ?? undefined}
            value={ctx.inputValue}
            onChange={ev => ctx.handleInputChange(ev.target.value)}
            onBlur={ctx.handleInputLostFocus}/>
    );
}