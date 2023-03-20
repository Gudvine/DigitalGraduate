import React from "react";
import { IconBaseProps } from "../../icons/@icons.types";

export const SettingsIcon: React.FC<IconBaseProps> = ({
  color,
  width,
  height,
  disabled,
  ...rest
}) => (
  <svg
    width={width}
    height={height}
    viewBox="0 0 12 16"
    fill="none"
    xmlns="http://www.w3.org/2000/svg"
    {...rest}
  >
    <path
      d="M2.5 9C3.88071 9 5 10.1193 5 11.5C5 12.8807 3.88071 14 2.5 14C1.11929 14 6.03528e-08 12.8807 0 11.5C-6.03528e-08 10.1193 1.11929 9 2.5 9Z"
      fill={disabled ? "var(--color-grey-primary)" : color}
    />
    <path d="M2 16L2 1.5299e-07L3 1.09278e-07L3 16H2Z" fill="black" />
    <path
      d="M9.5 0C10.8807 -6.03528e-08 12 1.11929 12 2.5C12 3.88071 10.8807 5 9.5 5C8.11929 5 7 3.88071 7 2.5C7 1.11929 8.11929 6.03528e-08 9.5 0Z"
      fill={disabled ? "var(--color-grey-primary)" : color}
    />
    <path
      d="M9 16L9 1.5299e-07L10 1.09278e-07L10 16H9Z"
      fill={disabled ? "var(--color-grey-primary)" : color}
    />
  </svg>
);

SettingsIcon.defaultProps = { width: "10", height: "14" };
