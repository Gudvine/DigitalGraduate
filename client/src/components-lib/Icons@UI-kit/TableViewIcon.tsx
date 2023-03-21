import React from "react";

type CheckIconProps = {
    color?: string;
    width?: number;
    height?: number;
};

export const TableViewIcon: React.FC<CheckIconProps> = ({ color = "#606060", width = 16, height = 10 }) => (
    <svg width={width} height={height} viewBox="0 0 16 10" fill="none" xmlns="http://www.w3.org/2000/svg">
        <path d="M1 1H2" stroke={color} strokeWidth="2" strokeLinecap="round" />
        <path d="M1 5H2" stroke={color} strokeWidth="2" strokeLinecap="round" />
        <path d="M1 9H2" stroke={color} strokeWidth="2" strokeLinecap="round" />
        <path d="M15 1H5" stroke={color} strokeWidth="2" strokeLinecap="round" />
        <path d="M15 5H5" stroke={color} strokeWidth="2" strokeLinecap="round" />
        <path d="M15 9H5" stroke={color} strokeWidth="2" strokeLinecap="round" />
    </svg>
);
