import React from "react";

import styles from "./Arrow.module.css";
import { ArrowSortDownIcon } from "../../Icons@UI-kit/ArrowSortDownIcon";
import { ArrowSortUpIcon } from "../../Icons@UI-kit/ArrowSortUpIcon";

type ArrowProps = {
  isArrowRotated: boolean;
};

export const Arrow: React.FC<ArrowProps> = (props) => {
  return (
    <div className={styles.tableRowItemHeaderIcon}>
      {props.isArrowRotated ? <ArrowSortDownIcon /> : <ArrowSortUpIcon />}
    </div>
  );
};
