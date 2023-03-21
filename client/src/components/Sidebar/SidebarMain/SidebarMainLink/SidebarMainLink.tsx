import React from "react";
import { NavLink} from "react-router-dom";

import styles from "./SidebarMainLink.module.css";

type Props = {
    title: string;
    to: string;
    icon?: JSX.Element
}

export const SidebarMainLink: React.FC<Props> = (props) => {
    return (
        <div className={styles.container}>
            <NavLink className={({isActive}) => isActive ? styles.active : styles.link} to={props.to}>
                <div className={styles.icon}>{props.icon}</div>
                {props.title}
            </NavLink>
        </div>
    )
}

