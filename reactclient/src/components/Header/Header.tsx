import React, {ReactNode} from "react";

import styles from "./Header.module.css";

interface IHeader {
    children: ReactNode;
}

export const Header: React.FC<IHeader> = (props) => {
    return (
        <div className={styles.container}>{props.children}</div>
    )
}