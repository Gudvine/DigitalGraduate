import { TChangeEvent, TMouseEvent } from "../../../common/types";

export const useImage = (
  image: string,
  changeImage: (image: any) => void
): [
  image: string,
  getLoadImage: (e: TChangeEvent<HTMLInputElement>) => void,
  deleteImage: (e: TMouseEvent<HTMLInputElement>) => void,
  removeCurrentImage: (e: TMouseEvent<HTMLInputElement>) => void
] => {
  const getLoadImage = (e: TChangeEvent<HTMLInputElement>): void => {
    const reader = new FileReader();
    // @ts-ignore
    reader.readAsDataURL(e.currentTarget.files[0]);
    reader.onload = () => {
      console.log("image: ", String(reader.result));
      changeImage(String(reader.result));
    };
  };

  const deleteImage = (e: TMouseEvent<HTMLInputElement>): void => {
    e.stopPropagation();
    e.preventDefault();
    changeImage(null);
  };

  const removeCurrentImage = (e: TMouseEvent<HTMLInputElement>): void => {
    // @ts-ignore
    e.currentTarget.value = null;
  };

  return [image, getLoadImage, deleteImage, removeCurrentImage];
};
