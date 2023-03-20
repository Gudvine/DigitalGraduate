import React from "react";

import styles from "./Loader.module.css";
import { styler } from "../../../utils/styler";

export type LoaderTheme = "blue" | "grey" | "white" | "grey-dark";

type LoaderProps = {
  scale?: number;
  theme?: LoaderTheme;
};

const themes: {
  [theme in LoaderTheme]: string;
} = {
  ["blue"]: styles.blue,
  ["grey"]: styles.grey,
  ["grey-dark"]: styles.greyDark,
  ["white"]: styles.white,
};

export const Loader: React.FC<LoaderProps> = (props) => {
  const scale = props.scale ?? 1;
  const theme = props.theme ?? "blue";

  return (
    <div
      className={styler(styles.template, styles.noFlick)}
      style={{ transform: `scale(${scale})` }}
    >
      <span
        className={styler(styles.square, styles.goDownAnimation, themes[theme])}
      />
      <span
        className={styler(styles.square, styles.goLeftAnimation, themes[theme])}
      />
      <span
        className={styler(styles.circle, styles.goLeftAnimation, themes[theme])}
      />
      <span
        className={styler(
          styles.circle,
          styles.dark,
          styles.goDownAnimation,
          themes[theme]
        )}
      />
      <span className={styler(styles.circle, styles.dark, themes[theme])} />
      <span
        className={styler(
          styles.square,
          styles.dark,
          styles.goUpAnimation,
          themes[theme]
        )}
      />
      <span
        className={styler(
          styles.circle,
          styles.goRightAnimation,
          themes[theme]
        )}
      />
      <span
        className={styler(
          styles.square,
          styles.goRightAnimation,
          themes[theme]
        )}
      />
      <span
        className={styler(styles.square, styles.goUpAnimation, themes[theme])}
      />
    </div>
  );
};
