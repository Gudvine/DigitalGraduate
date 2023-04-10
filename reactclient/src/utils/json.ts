import { parseJSON } from "date-fns";
import { Func1, Func2 } from "../common/types";

export const jsonParseDateReviver: Func2<string, string, string | Date> = (
  key,
  value
) => {
  if (typeof value === "string") {
    const date = parseJSON(value);
    if (date.toString() !== "Invalid Date") {
      return date;
    }
  }
  return value;
};

export const validateJson: Func1<string, boolean> = (str: string): boolean => {
  try {
    JSON.parse(str);
  } catch (e) {
    return false;
  }
  return true;
};
