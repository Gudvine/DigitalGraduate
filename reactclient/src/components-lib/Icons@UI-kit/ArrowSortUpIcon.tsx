import React from "react";
import { IconBaseProps } from "../../icons/@icons.types";

export const ArrowSortUpIcon: React.FC<IconBaseProps> = ({
  color,
  width,
  height,
  disabled,
  ...rest
}) => (
  <svg
    width={width}
    height={height}
    viewBox={`0 0 8 6`}
    fill="none"
    xmlns="http://www.w3.org/2000/svg"
    {...rest}
  >
    <path
      d="M4 0L8 6H0L4 0Z"
      fill={disabled ? "var(--color-grey-primary)" : color}
    />
  </svg>
);

ArrowSortUpIcon.defaultProps = { height: "6" };
