import React from "react";

type ForbiddenIconProps = {
    color?: string;
    width?: number;
    height?: number;
    disabled?: boolean;
};

export const ForbiddenIcon: React.FC<ForbiddenIconProps> = ({ color = "#999", width = 16, height = 16, disabled = false }) => (
    <svg width={width} height={height} viewBox="0 0 16 16" fill="none" xmlns="http://www.w3.org/2000/svg">
        <path
            d="M8 16C12.411 16 16 12.4113 16 8C16 5.86133 15.1683 3.85205 13.658 2.34196C12.1476 0.831706 10.1387 0 8 0C3.5887 0 0 3.5887 0 8C0 10.1387 0.831706 12.1479 2.34196 13.658C3.85205 15.1683 5.86133 16 8 16ZM8 14.6667C6.44206 14.6667 4.96663 14.137 3.7793 13.1634L13.1634 3.7793C14.137 4.96663 14.6667 6.44206 14.6667 8C14.6667 11.6759 11.6759 14.6667 8 14.6667ZM8 1.33333C9.55762 1.33333 11.0334 1.86296 12.2204 2.83659L2.83659 12.2207C1.86296 11.0334 1.33333 9.55794 1.33333 8C1.33333 4.32406 4.32406 1.33333 8 1.33333Z"
            fill={disabled ? "var(--color-grey-primary)" : color}
        />
    </svg>
);
