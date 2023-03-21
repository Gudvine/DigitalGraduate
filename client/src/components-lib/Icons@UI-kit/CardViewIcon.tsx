import React from "react";

type CheckIconProps = {
    color?: string;
    width?: number;
    height?: number;
};

export const CardViewIcon: React.FC<CheckIconProps> = ({ color = "#999", width = 16, height = 16 }) => (
    <svg width={width} height={height} viewBox="0 0 16 16" fill="none" xmlns="http://www.w3.org/2000/svg">
        <g>
            <rect x="1" y="10" width="5" height="5" stroke={color} strokeWidth="2" />
            <rect x="1" y="1" width="5" height="5" stroke={color} strokeWidth="2" />
            <rect x="10" y="10" width="5" height="5" stroke={color} strokeWidth="2" />
            <rect x="10" y="1" width="5" height="5" stroke={color} strokeWidth="2" />
        </g>
    </svg>
);
