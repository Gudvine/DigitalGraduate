import React from "react";
import {IconBaseProps} from "./@icons.types";

export const AddIcon: React.FC<IconBaseProps> = ({ color, width, height, disabled, viewBox }) => (
    <svg
        width={width}
        height={height}
        viewBox={viewBox}
        fill="none"
        xmlns="http://www.w3.org/2000/svg"
    >
        <line x1="13.9231" x2="9.6154" y2="28" stroke="white" stroke-width="2"/>
        <line x1="28" y1="13.9231" x2="-2.89168e-07" y2="9.61541" stroke="white" stroke-width="2"/>

    </svg>
);

AddIcon.defaultProps = { color: "#FFFFFF", width: "28", height: "28", disabled: false, viewBox: "0 0 28 28" };
