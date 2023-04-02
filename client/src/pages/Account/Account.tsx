import React from "react";
import styles from "./Account.module.css";
import {NavLink} from "react-router-dom";
import {ImageLoader} from "../../components-lib/ImageLoader";

export const Account: React.FC = () => {
    return (
        <div className={styles.container}>
            <div className={styles.sidebar}>
                <div style={{
                    display: "grid",
                    gridTemplateColumns: "200px 1fr",
                    gap: "10px"
                }}>
                    <div>
                        <ImageLoader
                            width={"200"}
                            height={"200"}
                            accept={["jpeg"]}
                            onChange={() => null}
                            value={"https://www.meme-arsenal.com/memes/7c2fa7a6f2801323e6570311feb25bcb.jpg"}
                            />
                    </div>
                    <div style={{
                        fontSize: "20px",
                        fontWeight: "700",
                    }}>
                        <p>{"Иванов"}</p>
                        <p>{"Иван"}</p>
                        <p>{"Иванович"}</p>
                    </div>
                </div>
                <NavLink className={styles.link} to={"/aboutpregraguateactivites"}>
                    {"Информация о доаспирантской деятельности"}
                </NavLink>
                <NavLink className={styles.link} to={"/enrollmentandgraduation"}>
                    {"Зачисление-выпуск"}
                </NavLink>
                <NavLink className={styles.link} to={"/scientificadviser"}>
                    {"Руководитель"}
                </NavLink>
                <NavLink className={styles.link} to={"/entrancetestresults"}>
                    {"Результаты вступительных испытаний"}
                </NavLink>
            </div>
        </div>
    );
}