import React, { PropsWithChildren, useEffect, useState } from "react";

import { Loader } from "../Loader";
import { LoaderTheme } from "../Loader/Loader";

import styles from "./PageLoader.style.css";
import { useLocationParams } from "../../../common/hooks/useLocationParams";

type PageLoaderProps<T> = {
  setParams: (params: T | null) => void;
  scale?: number;
  theme?: LoaderTheme;
};

export const PageLoader = <T extends Record<string, unknown>>(
  props: PropsWithChildren<PageLoaderProps<T>>
): JSX.Element => {
  const scale = props.scale ?? 1.8;
  const theme = props.theme ?? "grey-dark";

  const params = useLocationParams<T>(true);
  const [show, setShow] = useState<boolean>(false);

  useEffect(() => {
    props.setParams(params);
    setShow(true);
  }, []);

  return (
    <>
      {show ? (
        props.children
      ) : (
        <div className={styles.loader}>
          <Loader theme={theme} scale={scale} />
        </div>
      )}
    </>
  );
};
