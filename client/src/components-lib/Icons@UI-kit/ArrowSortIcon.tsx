import React from "react";
import { IconBaseProps } from "../../icons/@icons.types";

export const ArrowSortIcon: React.FC<IconBaseProps> = ({
  color,
  width,
  height,
  disabled,
  ...rest
}) => (
  <svg
    width={width}
    height={height}
    viewBox={`0 0 16 16`}
    fill="none"
    xmlns="http://www.w3.org/2000/svg"
    {...rest}
  >
    <path
      d="M8 15L4 9H12L8 15Z"
      fill={disabled ? "var(--color-grey-primary)" : color}
    />
    <path
      d="M8 1L12 7H4L8 1Z"
      fill={disabled ? "var(--color-grey-primary)" : color}
    />
  </svg>
);

ArrowSortIcon.defaultProps = {};
