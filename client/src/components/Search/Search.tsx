import React from "react";

import styles from "./Search.module.css";
import { FilterIcon } from "../../icons/FilterIcon";

type Props = {
  title: string;
};

export const Search: React.FC<Props> = (props) => {
  return (
    <div className={styles.container}>
      <input className={styles.input} placeholder={props.title} />
      <button className={styles.buttonFilter}>
        <FilterIcon />
      </button>
      <button className={styles.buttonSearch}>{"Найти"}</button>
    </div>
  );
};
