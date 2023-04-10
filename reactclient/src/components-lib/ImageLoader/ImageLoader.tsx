import React from "react";

import styles from "./ImageLoader.module.css";
import { styler } from "../../utils/styler";
import { useImage } from "./hooks/useImage";
import { CrossIcon } from "../Icons@UI-kit/CrossIcon";
import { DownloadIcon } from "../Icons@UI-kit/DownloadIcon";

type ImageLoaderProps = {
  /**
   * Ширина блока с изображением.
   * @default 100%
   */
  width?: string;

  /**
   * Высота блока с изображением.
   * @default 35px
   */
  height?: string;

  /**
   * Иконка, которая отображается в блоке input.
   * @default <DownloadSolidIcon />
   */
  icon?: JSX.Element;

  /**
   * Строка, которая отображается в блоке input.
   * @default null
   */
  title?: string;

  /**
   * Массив форматов, которые принимает компонент.
   * @default ["png", "jpg"]
   */
  accept: string[];

  /**
   * Состояние disabled компонента.
   * @default false
   */
  disabled?: boolean;

  /**
   * Альтернативный текст для области изображения.
   * @default null
   */
  alt?: string;

  /**
   * Ссылка на картинку или блок картинки.
   */
  value: string;

  /**
   * Состояние возможности редактирования содержимого.
   */
  readOnly?: boolean;

  /**
   * Функция для изменения картики.
   */
  onChange: (value: string) => void;
};

export const ImageLoader: React.FC<ImageLoaderProps> = (props) => {
  const {
    disabled,
    width,
    height,
    value,
    accept,
    alt,
    icon,
    title,
    readOnly,
    onChange,
  } = props;

  const [image, getLoadImage, deleteImage, removeCurrentImage] = useImage(
    value,
    onChange
  );

  const acceptString = accept.map((a) => "." + a).join(",");

  return (
    <form className={styles.form}>
      <label htmlFor={"image-downloader"}>
        <div
          className={styler(styles.loaderBlock, [
            !!image,
            styles.loaderBlockHidden,
          ])}
        >
          <div
            style={{ width: width, height: height }}
            className={styler(styles.imageLoaderWrapper, [
              disabled ?? true,
              styles.imageLoaderWrapperDisabled,
            ])}
          >
            {icon}
            <span className={styles.imageLoaderTitle}>{title}</span>
          </div>
        </div>
        <div
          className={styler(styles.imageBlock, [
            !image,
            styles.imageBlockHidden,
          ])}
        >
          <div
            className={styler(styles.imageWrapper, [
              Boolean(disabled),
              styles.imageWrapperDisabled,
            ])}
          >
            {readOnly ? (
              <></>
            ) : (
              <button
                className={styler(styles.crossButton, [
                  Boolean(disabled),
                  styles.crossButtonHidden,
                ])}
                // @ts-ignore
                onClick={deleteImage}
              >
                <CrossIcon />
              </button>
            )}
            <img
              className={styles.image}
              height={height}
              width={width}
              src={value}
              alt={alt}
            />
          </div>
        </div>
      </label>
      {readOnly ? (
        <></>
      ) : (
        <input
          disabled={disabled}
          className={styles.input}
          onChange={getLoadImage}
          onClick={removeCurrentImage}
          id={"image-downloader"}
          type="file"
          accept={acceptString}
          multiple={false}
        />
      )}
    </form>
  );
};

ImageLoader.defaultProps = {
  readOnly: false,
  disabled: false,
  height: "35px",
  width: "100%",
  accept: ["png", "jpg"],
  icon: <DownloadIcon />,
};
