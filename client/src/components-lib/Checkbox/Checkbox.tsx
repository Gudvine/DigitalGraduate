import React, { ReactNode, useState } from "react";
import { themes } from "./themes";
import styles from "./Checkbox.style.css";
import { TMouseEvent } from "../../common/types";
import { CheckIcon } from "../Icons@UI-kit/CheckIcon";
import { styler } from "../../utils/styler";

export type CheckboxTheme = keyof typeof themes;

type CheckboxProps = {
  onSet?: () => void;
  onUnset?: () => void;
  onChange?: () => void;
  checked: boolean;
  text?: string;
  controlled?: boolean;
  disabled?: boolean;
  theme?: CheckboxTheme;
  children?: ReactNode;
};

export const Checkbox: React.FC<CheckboxProps> = (props) => {
  const [checked, setChecked] = useState(props.checked);

  const currentTheme = props.theme ?? "plain-white";
  const themeStyles = themes[currentTheme];

  const onChange = (e: TMouseEvent<HTMLSpanElement>): void => {
    e.stopPropagation();

    if (props.disabled) {
      return;
    }

    props.onChange?.();
    if (!checked) {
      props.onSet?.();
    } else {
      props.onUnset?.();
    }
    setChecked(!checked);
  };

  const value = props.controlled ? props.checked : checked;

  return (
    <span className={styles.container} onClick={onChange}>
      <input
        className={styles.checkboxInput}
        type="checkbox"
        checked={value}
        readOnly={true}
        disabled={props.disabled}
      />
      <span
        className={styler(
          styles.checkbox,
          themeStyles.checkbox,
          [value, themeStyles.checkboxChecked],
          [Boolean(props.disabled), styles.checkboxDisabled]
        )}
      >
        <span className={styler(styles.icon, [value, styles.iconChecked])}>
          <CheckIcon width={12} height={12} color={"#fff"} />
        </span>
      </span>
      {props.children}
      {!!props.text && <span className={styles.text}>{props.text}</span>}
    </span>
  );
};
