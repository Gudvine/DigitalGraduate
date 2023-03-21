import React from "react";

const directions = {
    left: "flex-start",
    right: "flex-end",
    center: "center",
};

export const getAlignTextStyles = (direction: "left" | "right" | "center"): React.CSSProperties => ({
    display: "flex",
    justifyContent: directions[direction],
    width: "100%",
    padding: "8px",
    boxSizing: "border-box",
});
