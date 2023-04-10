import React, { useEffect, useState } from "react";

import styles from "./Spinner.module.css";
import { styler } from "../../utils/styler";

type SpinnerProps = {
  size?: number;
  delay?: number;
};

export const Spinner: React.FC<SpinnerProps> = (props) => {
  const [show, setShow] = useState<boolean>(false);

  const size = props.size ?? 1.3;

  useEffect(() => {
    const timerId = setTimeout(() => setShow(true), props.delay ?? 100);
    return () => clearTimeout(timerId);
  }, [props.delay]);

  return (
    <span
      className={styler(styles.loader, [show, styles.loaderShow])}
      style={{ width: `${size}em`, height: `${size}em` }}
    />
  );
};
