import { CommandStatus } from "./types";

export const appName = "React App Template";

export const initCommandStatus: CommandStatus = {
  count: 0,
  error: null,
  refresh: false,
};

export const dateFormat = "dd-MM-yyyy";
export const timeFormat = "HH:mm";
export const dateTimeFormat = `${dateFormat} ${timeFormat}`;

export const dateLargeFormat = "dd MMMM yyyy";
export const dateTimeLargeFormat = `${timeFormat} ${dateLargeFormat}`;

export const externalPortalsConfig = [];
export const defaultModalCloseOnSuccess = 1000;
