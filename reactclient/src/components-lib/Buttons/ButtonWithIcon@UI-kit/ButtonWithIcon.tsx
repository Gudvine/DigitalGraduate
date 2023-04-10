import React from "react";
import styles from "../../Icons@UI-kit/ThemeIcon/ThemeIcon.style.css";
import { themes } from "../../Icons@UI-kit/ThemeIcon/themes";
import { Button, ButtonTheme } from "../Button@UI-kit/Button";

export interface ButtonProps extends React.ComponentPropsWithoutRef<"button"> {
  theme?: ButtonTheme;
  isActive?: boolean;
}

export const ButtonWithIcon: React.FC<ButtonProps> = (props) => {
  const { isActive, theme, ...rest } = props;
  const currentTheme = theme ?? "primary-blue";
  const iconStyles = props.disabled ? styles : themes[currentTheme];

  return (
    <Button
      {...rest}
      theme={theme}
      isActive={isActive}
      mixClassName={iconStyles.iconController}
    >
      {props.children}
    </Button>
  );
};
