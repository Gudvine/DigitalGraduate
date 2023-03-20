import React from "react";
import { styler } from "../../../utils/styler";
import styles from "./ClearCheckboxesButton.style.css";

type ClearCheckboxesButtonProps = {
    isAllCheckboxUnchecked: boolean;
    resetAllCheckboxes: () => void;
};

export const ClearCheckboxesButton: React.FC<ClearCheckboxesButtonProps> = (props) => {
    return (
        <button
            className={styler(styles.clearCheckboxButton, [props.isAllCheckboxUnchecked, styles.clearCheckboxButtonHidden])}
            onClick={props.resetAllCheckboxes}
        >
            <span className={styles.clearCheckboxButtonText}>{"Снять выделение"}</span>
        </button>
    );
};
