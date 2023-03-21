import React from "react";
import { CheckIcon } from "../../Icons@UI-kit/CheckIcon";
import { CrossIcon } from "../../Icons@UI-kit/CrossIcon";
import { ButtonStateType } from "./PendingErrorButton";
import styles from "./PendingErrorButton.style.css";
import { Button } from "../Button@UI-kit/Button";

type PendingErrorButtonViewProps = {
  title: string;
  buttonState: ButtonStateType;
  onClick?: () => void;
  onModalClose?: () => void;
  disabled: boolean;
};

export const PendingErrorButtonView: React.FC<PendingErrorButtonViewProps> = (
  props
) => {
  const renderInitButton = (): JSX.Element => (
    <Button onClick={props.onClick} disabled={props.disabled}>
      {props.title}
    </Button>
  );

  const renderPendingButton = (): JSX.Element => (
    <Button style={{ cursor: "wait" }}>
      {"В процессе"}
      <div className={styles.pendingContainer}>
        <span className={styles.dot} />
        <span className={styles.dot} style={{ animationDelay: "0.3s" }} />
        <span className={styles.dot} style={{ animationDelay: "0.6s" }} />
      </div>
    </Button>
  );

  const renderSuccessButton = (): JSX.Element => (
    // <Button theme={"primary-green"} onClick={props.onModalClose}>
    <Button onClick={props.onModalClose}>
      {"Успешно"}
      <CheckIcon color={"#fff"} width={12} height={10} />
    </Button>
  );

  const renderErrorButton = (): JSX.Element => (
    // <Button theme={"primary-red"} onClick={props.onClick}>
    <Button onClick={props.onClick}>
      {"Ошибка"}
      <CrossIcon color={"#fff"} />
    </Button>
  );

  return (
    <>
      {props.buttonState === "init" && renderInitButton()}
      {props.buttonState === "pending" && renderPendingButton()}
      {props.buttonState === "success" && renderSuccessButton()}
      {props.buttonState === "error" && renderErrorButton()}
    </>
  );
};
