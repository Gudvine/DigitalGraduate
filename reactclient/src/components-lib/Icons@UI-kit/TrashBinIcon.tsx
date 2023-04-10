import React from "react";

type TrashBinIconProps = {
    color?: string;
    width?: number;
    height?: number;
    disabled?: boolean;
};

export const TrashBinIcon: React.FC<TrashBinIconProps> = ({ color = "#999", width = 14, height = 14, disabled = false }) => (
    <svg width={width} height={height} viewBox="0 0 15 16" fill="none" xmlns="http://www.w3.org/2000/svg">
        <path
            d="M10.5059 5.51378L9.25394 5.46777L8.98193 12.8828L10.2339 12.9288L10.5059 5.51378Z"
            fill={disabled ? "var(--color-grey-primary)" : color}
        />
        <path d="M8.08308 5.49316H6.83008V12.9082H8.08308V5.49316Z" fill={disabled ? "var(--color-grey-primary)" : color} />
        <path
            d="M5.93121 12.8852L5.65923 5.47021L4.40723 5.51622L4.67921 12.9312L5.93121 12.8852Z"
            fill={disabled ? "var(--color-grey-primary)" : color}
        />
        <path
            d="M0 2.40186V3.65486H1.306L2.342 15.4279C2.35552 15.584 2.42713 15.7294 2.54266 15.8353C2.6582 15.9412 2.80926 15.9999 2.966 15.9999H11.927C12.0837 15.9999 12.2348 15.9412 12.3503 15.8353C12.4659 15.7294 12.5375 15.584 12.551 15.4279L13.587 3.65486H14.914V2.40186H0ZM11.353 14.7469H3.54L2.564 3.65486H12.329L11.353 14.7469Z"
            fill={disabled ? "var(--color-grey-primary)" : color}
        />
        <path
            d="M9.50421 0H5.4102C5.13348 0.000528604 4.86825 0.110691 4.67258 0.306364C4.4769 0.502038 4.36674 0.767276 4.36621 1.044V3.029H5.6192V1.253H9.29521V3.029H10.5482V1.044C10.5477 0.767276 10.4375 0.502038 10.2418 0.306364C10.0462 0.110691 9.78094 0.000528604 9.50421 0V0Z"
            fill={disabled ? "var(--color-grey-primary)" : color}
        />
    </svg>
);
