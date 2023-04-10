import React from "react";

import styles from "./DualCounter.style.css";
import { formatNumber } from "../../../utils/format-numbers";

type DualCounterProps = {
  selectedCount: number;
  totalCount: number;
};

export const DualCounter: React.FC<DualCounterProps> = (props) => {
  return (
    <div className={styles.container}>
      <span className={styles.counter}>
        {formatNumber(props.selectedCount)}
      </span>
      {` / `}
      <span className={styles.counter}>{formatNumber(props.totalCount)}</span>
    </div>
  );
};
