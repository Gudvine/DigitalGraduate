import React, { ReactNode } from "react";

import styles from "./Stub.style.css";

type StubWarningProps = {
  show: boolean;
  text: string;
  children?: ReactNode;
};

export const Stub: React.FC<StubWarningProps> = (props) => {
  return (
    <>
      {props.show ? (
        <div className={styles.container}>{props.text}</div>
      ) : (
        props.children
      )}
    </>
  );
};
