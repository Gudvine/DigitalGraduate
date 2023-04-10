import React from "react";

import { formatNumber } from "../../../utils/format-numbers";
import { styler } from "../../../utils/styler";
import { Spinner } from "../../Spinner";

import styles from "./Counter.style.css";

type CounterProps = {
    counter: number;
    title: string;
    pending?: boolean;
};

export const Counter: React.FC<CounterProps> = (props) => {
    return (
        <div className={styles.counterWrap}>
            <p className={styler(styles.text, styles.counterTitle)}>{props.title}</p>
            {props.pending ? <Spinner /> : <p className={styler(styles.text, styles.counter)}>{formatNumber(props.counter)}</p>}
        </div>
    );
};
