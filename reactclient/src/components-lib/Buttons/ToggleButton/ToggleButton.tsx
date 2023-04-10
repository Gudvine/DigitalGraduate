import React, { useState } from "react";
import styles from "./ToggleButton.style.css";

type ToggleButtonProps = {
    title: string;
    onToggleClick: () => void;

    toggledTitle?: string;
    isInitText?: boolean;
    withoutToggling?: boolean;
};

export const ToggleButton: React.FC<ToggleButtonProps> = (props) => {
    const [switched, setSwitched] = useState<boolean>(false);

    const withoutToggling = props.withoutToggling ?? false;
    const isInitText = props.isInitText ?? true;
    const toggledTitle = props.toggledTitle ?? "";

    const handleToggleClick = (): void => {
        if (withoutToggling) {
            if (!switched) {
                props.onToggleClick();
                setSwitched(true);
            }
        } else {
            props.onToggleClick();
        }
    };

    return (
        <button className={styles.toggleButton} onClick={handleToggleClick}>
            {isInitText ? props.title : toggledTitle}
        </button>
    );
};
