import React from "react";

import { getAlignTextStyles } from "./customStyles";

import styles from "./HeaderText.module.css";
import { styler } from "../../../../utils/styler";

type HeaderTextProps = {
  isActive?: boolean;
  text: string;
  alignText?: "left" | "right" | "center";
  customStyles?: React.CSSProperties;
};

export const HeaderText: React.FC<HeaderTextProps> = (props) => {
  const textStyles = props.alignText
    ? { ...getAlignTextStyles(props.alignText), ...props.customStyles }
    : props.customStyles;

  return (
    <p
      className={styler(styles.headerItemText, [
        Boolean(props.isActive),
        styles.headerItemTextActive,
      ])}
      style={textStyles}
    >
      {props.text}
    </p>
  );
};
