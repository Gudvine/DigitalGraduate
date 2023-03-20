import React from "react";

import { styler } from "../../../utils/styler";
import { themes } from "./themes";

import styles from "./Button.module.css";

export type ButtonTheme = keyof typeof themes;

export interface ButtonProps extends React.ComponentPropsWithoutRef<"button"> {
  theme?: ButtonTheme;
  isActive?: boolean;
  mixClassName?: string;
}

export const Button: React.FC<ButtonProps> = (props) => {
  const { isActive, theme, mixClassName, ...rest } = props;
  const currentTheme = theme ?? "primary-blue";
  const themeStyles = themes[currentTheme];

  const withOnlyIcon = React.Children.toArray(props.children).every(
    (c) => typeof c !== "string"
  );
  const childrenCount = React.Children.count(props.children);
  const inlineComputedStyles = {
    gridTemplateColumns: `repeat(${childrenCount}, max-content)`,
  };

  return (
    <button
      {...rest}
      style={{ ...inlineComputedStyles, ...rest.style }}
      className={styler(
        styles.button,
        themeStyles.button,
        mixClassName ?? "",
        [withOnlyIcon, styles.buttonWithIcon]
        // [Boolean(isActive), themeStyles.buttonActive]
      )}
    >
      {props.children}
    </button>
  );
};
