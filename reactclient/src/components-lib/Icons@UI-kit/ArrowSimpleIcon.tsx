import React from "react";

type ArrowIconProps = {
    color?: string;
    width?: number;
    height?: number;
    rotate?: number;
    disabled?: boolean;
};

export const ArrowSimpleIcon: React.FC<ArrowIconProps> = ({ color = "#338fd0", width = 6, height = 8, rotate = 0, disabled = false }) => (
    <svg width={width} height={height} viewBox="0 0 6 8" fill="none" xmlns="http://www.w3.org/2000/svg">
        <g transform={`rotate(${rotate} 3 4)`}>
            <path
                d="M1.06961 3.70868L4.40711 0.371177C4.44536 0.332834 4.49081 0.302414 4.54084 0.281658C4.59087 0.260902 4.6445 0.250219 4.69867 0.250219C4.75283 0.250219 4.80647 0.260902 4.8565 0.281658C4.90653 0.302414 4.95197 0.332834 4.99023 0.371177L5.37961 0.760552C5.4567 0.837876 5.49999 0.942611 5.49999 1.0518C5.49999 1.16099 5.4567 1.26573 5.37961 1.34305L2.73523 3.99993L5.38023 6.65743C5.45733 6.73475 5.50062 6.83949 5.50062 6.94868C5.50062 7.05787 5.45733 7.1626 5.38023 7.23993L4.99086 7.6293C4.91351 7.70659 4.80864 7.75 4.69929 7.75C4.58995 7.75 4.48508 7.70659 4.40773 7.6293L1.07023 4.2918C0.992862 4.21453 0.949336 4.10971 0.949219 4.00037C0.949102 3.89102 0.992403 3.78611 1.06961 3.70868V3.70868Z"
                fill={disabled ? "var(--color-grey-dark)" : color}
            />
        </g>
    </svg>
);
