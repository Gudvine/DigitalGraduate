import React from "react";

type DisketteIconProps = {
    color?: string;
    width?: number;
    height?: number;
    disabled?: boolean;
};

export const DisketteIcon: React.FC<DisketteIconProps> = ({ color = "#999", width = 16, height = 16, disabled = false }) => (
    <svg width={width} height={height} viewBox="0 0 16 16" fill="none" xmlns="http://www.w3.org/2000/svg">
        <path
            d="M15.414 2.414L13.586 0.586C13.211 0.210901 12.7024 0.000113275 12.172 0L11 0V3.5C11 3.63261 10.9473 3.75979 10.8536 3.85355C10.7598 3.94732 10.6326 4 10.5 4H2.5C2.36739 4 2.24021 3.94732 2.14645 3.85355C2.05268 3.75979 2 3.63261 2 3.5V0H1C0.734784 0 0.48043 0.105357 0.292893 0.292893C0.105357 0.48043 0 0.734784 0 1L0 15C0 15.2652 0.105357 15.5196 0.292893 15.7071C0.48043 15.8946 0.734784 16 1 16H15C15.2652 16 15.5196 15.8946 15.7071 15.7071C15.8946 15.5196 16 15.2652 16 15V3.828C15.9999 3.29761 15.7891 2.78899 15.414 2.414ZM14 14H2V8H14V14Z"
            fill={disabled ? "var(--color-grey-primary)" : color}
        />
        <path d="M9 0H7V3H9V0Z" fill={disabled ? "var(--color-grey-primary)" : color} />
    </svg>
);
