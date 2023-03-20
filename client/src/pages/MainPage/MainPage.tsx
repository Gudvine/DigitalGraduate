import React from "react";

import styles from "./MainPage.module.css";
import {TitlePage} from "../../components/TitlePage";
import {Search} from "../../components/Search";
import {AddIcon} from "../../icons/AddIcon";
import {SettingsIcon} from "../../icons/Settings";

export const MainPage: React.FC = () => {
    return (
        <div className={styles.container}>
            <header className={styles.header}>
                <TitlePage title={"Организации"} />
                <div className={styles.wrapper}>
                    <Search title={"Поиск организации по ИНН или ОГРН"} />
                    <div className={styles.buttons}>
                        <button className={styles.button}><AddIcon /></button>
                        <button className={styles.button}><SettingsIcon /></button>
                    </div>
                </div>
            </header>
        </div>
    )
}