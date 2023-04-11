import React, {useEffect} from "react";
import styles from "./Account.module.css";
import {NavLink} from "react-router-dom";
import {ImageLoader} from "../../components-lib/ImageLoader";
import {useSelector} from "react-redux";
import {selector} from "./@services/getter";
import {loadAspirantData} from "./@services/command";

export const Account: React.FC = () => {
    const state = useSelector(selector);

    useEffect(   () => {
        (async function anyFunc(){
            await loadAspirantData()
        })();
    }, []);

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
                        <p>{state.secondName}</p>
                        <p>{state.firstName}</p>
                        <p>{state.patronymic}</p>
                        <p>{state.department?.name}</p>
                        <p>{state.phoneNumber}</p>
                        {/* <p>{state.dateOfBirth}</p>
                        <p>{state.education}</p>
                        <p>{state.institute?.name}</p>
                        <p>{state.scientificSpeciality}</p>
                        <p>{state.formOfStudy}</p>
                        <p>{state.budgetForm}</p>
                        <p>{state.studyStatus}</p> */}
                        <input type="file"/>
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