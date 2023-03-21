import React from "react";

import { Arrow } from "../Arrow";

import styles from "./ArrowWithLetters.module.css";
import { styler } from "../../../utils/styler";

type ArrowWithLettersProps = {
  isArrowRotated: boolean;
};

export const ArrowWithLetters: React.FC<ArrowWithLettersProps> = (props) => {
  const topLetter = props.isArrowRotated ? "А" : "Я";
  const bottomLetter = props.isArrowRotated ? "Я" : "А";
  return (
    <div className={styles.container}>
      <div className={styles.letters}>
        <span className={styler(styles.letter, styles.letterUpper)}>
          {topLetter}
        </span>
        <span className={styler(styles.letter, styles.letterBottom)}>
          {bottomLetter}
        </span>
      </div>
      <Arrow isArrowRotated={props.isArrowRotated} />
    </div>
  );
};
