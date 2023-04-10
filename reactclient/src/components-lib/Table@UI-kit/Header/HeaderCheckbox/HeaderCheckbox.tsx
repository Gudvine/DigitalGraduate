import React from "react";

import styles from "./HeaderCheckbox.module.css";
import { Checkbox } from "../../../Checkbox";

type HeaderTextProps = {
  isSelected: boolean;
  onSelect: () => void;
};

export const HeaderCheckbox: React.FC<HeaderTextProps> = (props) => {
  return (
    <div className={styles.container}>
      <Checkbox checked={props.isSelected} onChange={props.onSelect} />
    </div>
  );
};
