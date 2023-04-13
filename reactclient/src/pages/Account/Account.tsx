import React, {useEffect} from "react";
import styles from "./Account.module.css";
import {Link, NavLink} from "react-router-dom";
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
                        <p>{state.dateOfBirth}</p>
                        <p>{state.phoneNumber}</p>
                        <p>{state.education}</p>
                        <p>{state.institute?.name}</p>
                        <p>{state.department?.name}</p>
                        <p>{state.scientificSpeciality}</p>
                        <p>{state.formOfStudy}</p>
                        <p>{state.budgetForm}</p>
                        <p>{state.studyStatus}</p>
                        <input type="file"/>
                    </div>
                </div>
                <Link className={styles.link} to={"/aboutpregraguateactivites"}>
                    {"Информация о доаспирантской деятельности"}
                </Link>
                <Link className={styles.link} to={"/enrollmentandgraduation"}>
                    {"Зачисление-выпуск"}
                </Link>
                <Link className={styles.link} to={"/scientificadviser"}>
                    {"Руководитель"}
                </Link>
                <Link className={styles.link} to={"/entrancetestresults"}>
                    {"Результаты вступительных испытаний"}
                </Link>
                <Link className={styles.link} to={"/сertification"}>
                    {"Аттестация"}
                </Link>
                <Link className={styles.link} to={"/scientificpublications"}>
                    {"Научные публикации"}
                </Link>
                <Link className={styles.link} to={"/scientificconferences"}>
                    {"Участие в научных конференциях"}
                </Link>
                <Link className={styles.link} to={"/scientificcompetitions"}>
                    {"Участие в научных конкурсах (за стипендию)"}
                </Link>
                <Link className={styles.link} to={"/patents"}>
                    {"Патенты"}
                </Link>
                <Link className={styles.link} to={"/certificateofstateprogramregistration"}>
                    {"Свидетельство о государственной регистрации программы/баз данных"}
                </Link>
                <Link className={styles.link} to={"/tuitionpayment"}>
                    {"Оплата обучения"}
                </Link>
                <Link className={styles.link} to={"/grantsparticipation"}>
                    {"Участие в грантах"}
                </Link>
            </div>
        </div>
    );
}