import React from "react";
import styles from "./Layout.module.css";
import {NavLink, Outlet} from "react-router-dom";
import {Button} from "../../components-lib/Buttons/Button@UI-kit/Button";
import {Header} from "../Header";

export const Layout:React.FC = () => {
    return (
      <div>
          <Header>
              <p className={styles.title}>{"ЦИФРОВАЯ АСПИРАНТУРА"}</p>
              <div className={styles.functionalButtons}>
                  <Button theme={"primary-red"}>
                      {"Заказ справок"}
                  </Button>
                  <Button>
                      {"Моя карточка"}
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
              <aside>
                  <div className={styles.sidebar}>
                      <NavLink className={({isActive}) => isActive ? styles.linkActive : styles.link} to={"/"}>{"Личный кабинет"}</NavLink>
                      <NavLink className={({isActive}) => isActive ? styles.linkActive : styles.link} to={"/aboutpregraguateactivites"}>{"Информация о доаспирантской деятельности"}</NavLink>
                      <NavLink className={({isActive}) => isActive ? styles.linkActive : styles.link} to={"/enrollmentandgraduation"}>{"Зачисление-выпуск"}</NavLink>
                      <NavLink className={({isActive}) => isActive ? styles.linkActive : styles.link} to={"/scientificadviser"}>{"Руководитель"}</NavLink>
                      <NavLink className={({isActive}) => isActive ? styles.linkActive : styles.link} to={"/entrancetestresults"}>{"Результаты вступительных испытаний"}</NavLink>
                  </div>
              </aside>
              <div className={styles.pageContent}>
                  <Outlet />
              </div>
          </div>
      </div>
    );
}