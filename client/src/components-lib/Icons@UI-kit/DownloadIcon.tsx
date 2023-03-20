import React from "react";

type DownloadIconProps = {
    color?: string;
    width?: number;
    height?: number;
    disabled?: boolean;
};

export const DownloadIcon: React.FC<DownloadIconProps> = ({ color = "#999", width = 14, height = 14, disabled = false }) => (
    <svg width={width} height={height} viewBox="0 0 16 16" fill="none" xmlns="http://www.w3.org/2000/svg">
        <path
            d="M14.75 6.30713V12.2801C14.75 12.7541 14.47 13.1391 14.125 13.1391H1.875C1.53 13.1391 1.25 12.7541 1.25 12.2801V6.30713H0V12.2801C0 13.7021 0.841 14.8581 1.875 14.8581H14.125C15.159 14.8581 16 13.7021 16 12.2801V6.30713H14.75Z"
            fill={disabled ? "var(--color-grey-primary)" : color}
        />
        <path
            d="M10.896 7.112L8.603 9.405V0H7.396V9.405L5.103 7.112L4.25 7.965L8 11.715L11.75 7.965L10.896 7.112Z"
            fill={disabled ? "var(--color-grey-primary)" : color}
        />
    </svg>
);
