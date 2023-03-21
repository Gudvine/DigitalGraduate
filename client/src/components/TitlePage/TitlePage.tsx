import React from "react";

import styles from "./TitlePage.module.css";

type Props = {
  title: string;
};

export const TitlePage: React.FC<Props> = (props) => {
  return <h1 className={styles.title}>{props.title}</h1>;
};
