import React from "react";
import {SidebarLink} from "../SidebarLink";
import {UserIcon} from "../../../icons/UserIcon";
import {HomeIcon} from "../../../icons/HomeIcon";

import styles from "./SidebarMain.module.css";
import {SidebarMainLink} from "./SidebarMainLink";

export const SidebarMain: React.FC = () => {

    return (
        <div className={styles.container}>
            <SidebarMainLink to={"/"} title={"Главная"} icon={<HomeIcon />} />
            <SidebarMainLink to={"/user"} title={"Константин Константиновский"} icon={<UserIcon />} />
        </div>
    )
}