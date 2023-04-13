import React from "react";
import styles from "../ScientificPublications.module.css";
import {Button} from "../../../components-lib/Buttons/Button@UI-kit/Button";

type Props = {
    title: string;
    edition: string;
    year: string;
    articleType: string;
    consultant: string;
}

export const PublicationItem: React.FC<Props> = (props) => {
    return (
        <div className={styles.publication}>
            <div className={styles.info}>
                <div className={styles.titleBlock}>
                    <p className={styles.title}>{"Название: "}</p>
                    <span>{props.title}</span>
                </div>
                <div className={styles.titleBlock}>
                    <p className={styles.title}>{"Издание: "}</p>
                    <span>{props.edition}</span>
                </div>
                <div className={styles.titleBlock}>
                    <p className={styles.title}>{"Год: "}</p>
                    <span>{props.year}</span>
                </div>
                <div className={styles.titleBlock}>
                    <p className={styles.title}>{"Вид статьи: "}</p>
                    <span>{props.articleType}</span>
                </div>
                <div className={styles.titleBlock}>
                    <p className={styles.title}>{"Консультант: "}</p>
                    <span>{props.consultant}</span>
                </div>
            </div>
            <Button className={styles.button} theme={"primary-green"}>
                {"Изменить"}
            </Button>
        </div>
    );
}