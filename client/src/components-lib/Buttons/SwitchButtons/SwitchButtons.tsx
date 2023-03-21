import React, { PropsWithChildren } from "react";
import { KeyValuePair } from "../../../common/types";
import { SwitchButtonsView } from "./SwitchButtons.view";

type SwitchButtonsProps<T> = {
    buttons: KeyValuePair<T, string>[];
    activeButton: T;
    setActiveButton: (key: T) => void;
    withIcons?: boolean;
    view?: "vertical" | "horizontal";
};

export const SwitchButtons = <T extends string>(
    props: PropsWithChildren<SwitchButtonsProps<T>>,
): React.ReactElement<SwitchButtonsProps<T>> => {
    const view = props.view ?? "horizontal";
    const isActive = (key: T): boolean => props.activeButton === key;
    const isLastButton = (i: number): boolean => props.buttons.length - 1 === i;
    const isMiddleButton = (i: number): boolean => i !== 0 && !isLastButton(i);

    return (
        <SwitchButtonsView
            buttons={props.buttons}
            setActiveButton={props.setActiveButton}
            withIcons={props.withIcons ?? false}
            isActive={isActive}
            isLastButton={isLastButton}
            isMiddleButton={isMiddleButton}
            view={view}
        >
            {props.children}
        </SwitchButtonsView>
    );
};
