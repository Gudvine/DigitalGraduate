import React, { Fragment } from "react";

import { getTheme, ThemeNames } from "../themes";

import styles from "./Row.style.css";
import { styler } from "../../../utils/styler";

export type OptionalEntityFields = {
  isActive?: boolean;
  onClick?: () => void;
};

type RowProps = {
  rowCells: JSX.Element[];
  gridColumns: string;
  rowStyles?: React.CSSProperties;
  theme?: ThemeNames;
} & OptionalEntityFields;

export const Row: React.FC<RowProps> = (props) => {
  const themeStyles = getTheme(props.theme ?? "portal-grey");

  return (
    <ul
      className={styler(styles.tableRow, themeStyles.tableRow, [
        Boolean(props.isActive),
        themeStyles.tableRowActive,
      ])}
      style={{ gridTemplateColumns: props.gridColumns, ...props.rowStyles }}
      onClick={props.onClick}
    >
      {props.rowCells.map((row, i) => (
        <Fragment key={i}>{row}</Fragment>
      ))}
    </ul>
  );
};
