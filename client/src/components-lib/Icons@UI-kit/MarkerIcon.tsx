import React from "react";

type MarkerIconProps = {
    color?: string;
    width?: number;
    height?: number;
    disabled?: boolean;
};

export const MarkerIcon: React.FC<MarkerIconProps> = ({ color = "#999", width = 11, height = 14, disabled = false }) => (
    <svg width={width} height={height} viewBox="0 0 11 14" fill="none" xmlns="http://www.w3.org/2000/svg">
        <path
            d="M5.33301 13.5857C5.19362 13.585 5.116 13.5647 4.7724 13.1571C1.8128 9.94137 0.333008 7.33446 0.333008 5.33637C0.333008 2.57336 2.57158 0.333496 5.33301 0.333496C8.09443 0.333496 10.333 2.57336 10.333 5.33637C10.333 8.3335 7.19156 11.6181 5.88878 13.1628C5.54798 13.5669 5.47239 13.5864 5.33301 13.5857ZM5.33301 7.35529C6.51648 7.35529 7.47586 6.41216 7.47586 5.24875C7.47586 4.08534 6.51648 3.14221 5.33301 3.14221C4.14954 3.14221 3.19015 4.08534 3.19015 5.24875C3.19015 6.41216 4.14954 7.35529 5.33301 7.35529Z"
            fill={disabled ? "var(--color-grey-primary)" : color}
        />
    </svg>
);
