import React, { Fragment } from "react";

import { getTheme, ThemeNames } from "../themes";

import styles from "./Header.module.css";
import { styler } from "../../../utils/styler";

type HeaderProps = {
  headerElements: JSX.Element[];
  gridColumns: string;
  theme?: ThemeNames;
};

export const Header: React.FC<HeaderProps> = (props) => {
  const themeStyles = getTheme(props.theme ?? "portal-grey");

  return (
    <div className={styles.tableHeader}>
      <ul
        className={styler(styles.headerRow, themeStyles.headerRow)}
        style={{ gridTemplateColumns: props.gridColumns }}
      >
        {props.headerElements.map((headerElement, i) => (
          <Fragment key={i}>{headerElement}</Fragment>
        ))}
      </ul>
    </div>
  );
};
