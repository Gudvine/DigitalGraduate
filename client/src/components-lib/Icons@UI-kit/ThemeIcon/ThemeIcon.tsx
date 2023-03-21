import React, { ReactNode } from "react";
import styles from "./ThemeIcon.style.css";
import { themes } from "./themes";

type ThemeIconProps = {
  theme: keyof typeof themes;
  disabled?: boolean;
  children?: ReactNode;
};

export const ThemeIcon: React.FC<ThemeIconProps> = (props) => {
  const themeStyles = props.disabled ? styles : themes[props.theme];

  return <span className={themeStyles.iconController}>{props.children}</span>;
};
