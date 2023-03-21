import React, { useEffect, useState } from "react";

import { PendingErrorButtonView } from "./PendingErrorButton.view";
import { PendingErrorBaseProps } from "../../../common/types";
import { defaultModalCloseOnSuccess } from "../../../common/consts";

export type PendingErrorButtonProps = {
  title: string;
  onClick?: () => void;
  onModalClose?: () => void;
  disabled?: boolean;
  autoCloseOnSuccess?: boolean;
} & PendingErrorBaseProps;

export type ButtonStateType = "init" | "pending" | "success" | "error";

export const PendingErrorButton: React.FC<PendingErrorButtonProps> = (
  props
) => {
  const [buttonState, setButtonState] = useState<ButtonStateType>("init");
  const [processingStarts, setProcessingStarts] = useState<boolean>(false);

  useEffect(() => {
    if (props.pending) {
      setButtonState("pending");
      setProcessingStarts(true);
    }

    if (!props.pending && processingStarts) {
      if (props.error) {
        setButtonState("error");
      } else {
        setButtonState("success");
      }
    }
  }, [props.pending, props.error, processingStarts]);

  useEffect(() => {
    let timerId: NodeJS.Timeout;
    if (buttonState === "success" && props.autoCloseOnSuccess) {
      timerId = setTimeout(() => {
        props.onModalClose?.();
      }, defaultModalCloseOnSuccess);
    }

    return () => clearTimeout(timerId);
  }, [buttonState, props.autoCloseOnSuccess]);

  return (
    <PendingErrorButtonView
      title={props.title}
      buttonState={buttonState}
      onClick={props.onClick}
      onModalClose={props.onModalClose}
      disabled={props.disabled ?? false}
    />
  );
};
