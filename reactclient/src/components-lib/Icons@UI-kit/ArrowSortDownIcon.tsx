import React from "react";
import { IconBaseProps } from "../../icons/@icons.types";

export const ArrowSortDownIcon: React.FC<IconBaseProps> = ({
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
      d="M4 6L0 0L8 0L4 6Z"
      fill={disabled ? "var(--color-grey-primary)" : color}
    />
  </svg>
);

ArrowSortDownIcon.defaultProps = { height: "6" };
