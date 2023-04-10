import React from "react";

type ExportIconProps = {
    color?: string;
    width?: number;
    height?: number;
    disabled?: boolean;
};

export const ExportIcon: React.FC<ExportIconProps> = ({ color = "#999", width = 15, height = 14, disabled = false }) => (
    <svg width={width} height={height} viewBox="0 0 16 16" fill="none" xmlns="http://www.w3.org/2000/svg">
        <path
            d="M14.75 9.75879V14.1028C14.7497 14.2685 14.6838 14.4273 14.5666 14.5444C14.4495 14.6616 14.2907 14.7275 14.125 14.7278H1.875C1.70932 14.7275 1.5505 14.6616 1.43335 14.5444C1.3162 14.4273 1.25026 14.2685 1.25 14.1028V9.75879H0V14.1028C0.000529413 14.5999 0.198243 15.0765 0.54976 15.428C0.901276 15.7796 1.37788 15.9773 1.875 15.9778H14.125C14.6221 15.9773 15.0987 15.7796 15.4502 15.428C15.8018 15.0765 15.9995 14.5999 16 14.1028V9.75879H14.75Z"
            fill={disabled ? "var(--color-grey-primary)" : color}
        />
        <path
            d="M8 0L4.116 3.884L5 4.768L7.375 2.393V12.134H8.625V2.393L11 4.768L11.884 3.884L8 0Z"
            fill={disabled ? "var(--color-grey-primary)" : color}
        />
    </svg>
);
