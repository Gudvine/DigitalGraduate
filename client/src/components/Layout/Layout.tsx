import React from "react";
import { Sidebar } from "../Sidebar";
import { Outlet } from "react-router";

import styles from "./Layout.module.css";

export const Layout: React.FC = () => {
  return (
    <div className={styles.container}>
      {/*<Sidebar />*/}
      <div className={styles.outlet}>{/*<Outlet />*/}</div>
    </div>
  );
};
