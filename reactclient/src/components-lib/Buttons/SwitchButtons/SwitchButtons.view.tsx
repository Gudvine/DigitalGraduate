import React, { PropsWithChildren } from "react";
import { KeyValuePair } from "../../../common/types";
import { styler } from "../../../utils/styler";
import styles from "./SwitchButtons.style.css";

type SwitchButtonsViewProps<T> = {
    buttons: KeyValuePair<T, string>[];
    setActiveButton: (key: T) => void;
    isActive: (key: T) => boolean;
    isLastButton: (i: number) => boolean;
    isMiddleButton: (i: number) => boolean;
    withIcons: boolean;
    view: "vertical" | "horizontal";
};

export const SwitchButtonsView = <T extends string>(
    props: PropsWithChildren<SwitchButtonsViewProps<T>>,
): React.ReactElement<SwitchButtonsViewProps<T>> => {
    return (
        <div className={styler(styles.container, [props.view === "vertical", styles.containerVertical])}>
            {props.buttons.map((button, i) => (
                <button
                    key={button.key}
                    className={styler(
                        styles.button,
                        [props.view === "vertical", styles.buttonVertical],
                        [props.isActive(button.key), styles.buttonActive],
                        [props.isLastButton(i), styles.buttonLast],
                        [props.isLastButton(i) && props.view === "vertical", styles.buttonLastVertical],
                        [props.isMiddleButton(i), styles.buttonMiddle],
                        [props.isMiddleButton(i) && props.view === "vertical", styles.buttonMiddleVertical],
                    )}
                    onClick={() => props.setActiveButton(button.key)}
                >
                    {props.withIcons ? (
                        <>{React.Children.map(props.children, (child, iconIndex) => iconIndex === i && child)}</>
                    ) : (
                        <span className={styles.buttonText}>{button.value}</span>
                    )}
                </button>
            ))}
        </div>
    );
};
