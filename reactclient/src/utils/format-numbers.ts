import { Func1 } from "../common/types";

export const formatNumber: Func1<number, string> = (number) => {
  // Заменяем &nbsp на пробел, т.к. toLocaleString() возвращает &nbsp.
  return typeof number === "number"
    ? number.toLocaleString().replace(/\xA0/g, " ")
    : "";
};
