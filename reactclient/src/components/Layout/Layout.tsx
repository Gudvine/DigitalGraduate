import React from "react";
import styles from "./Layout.module.css";
import {Outlet} from "react-router-dom";
import {Button} from "../../components-lib/Buttons/Button@UI-kit/Button";
import {Header} from "../Header";

export const Layout:React.FC = () => {

    return (
      <div>
          <Header>
              <p className={styles.title}>{"ЦИФРОВАЯ АСПИРАНТУРА"}</p>
              <div className={styles.functionalButtons}>
                  <Button theme={"primary-red"}>
                      {"Справки"}
                  </Button>
                  <Button>
                      {"Приказы"}
                  </Button>
              </div>
              <div className={styles.account}>
                  <a href="#">
                      {"Иванов И. И."}
                  </a>
                  <Button theme={"primary-red"}>
                      {"Выйти"}
                  </Button>
              </div>
          </Header>
          <div className={styles.content}>
              <div className={styles.pageContent}>
                  <Outlet />
              </div>
          </div>
      </div>
    );
}