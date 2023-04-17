import React from "react";
import styles from "./RegistrationFormPage.module.css";
import {Button} from "../../components-lib/Buttons/Button@UI-kit/Button";

export const RegistrationFormPage: React.FC = () => {
    return (
      <div className={styles.container}>
          <div className={styles.form}>
              <input placeholder={"Логин"} type="text"/>
              <input placeholder={"Пароль"} type="text"/>
              <Button theme={"primary-green"}>{"Зарегестрироваться"}</Button>
          </div>
      </div>
    );
}