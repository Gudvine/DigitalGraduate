import React from "react";

export type TMouseEvent<T> = React.MouseEvent<T, MouseEvent>;
export type TKeyboardEvent<T> = React.KeyboardEvent<T>;
export type TChangeEvent<T> = React.ChangeEvent<T>;

export type Func0<TResult = void> = () => TResult;
export type Func1<TArg, TResult = void> = (arg: TArg) => TResult;
export type Func2<TArg0, TArg1, TResult = void> = (arg0: TArg0, arg1: TArg1) => TResult;
export type Func3<TArg0, TArg1, TArg2, TResult = void> = (arg0: TArg0, arg1: TArg1, arg2: TArg2) => TResult;
export type Func4<TArg0, TArg1, TArg2, TArg3, TResult = void> = (arg0: TArg0, arg1: TArg1, arg2: TArg2, arg3: TArg3) => TResult;

export type AsyncFunc0<TResult = void> = () => Promise<TResult>;
export type AsyncFunc1<TArg, TResult = void> = (arg: TArg) => Promise<TResult>;
export type AsyncFunc2<TArg0, TArg1, TResult = void> = (arg0: TArg0, arg1: TArg1) => Promise<TResult>;
export type AsyncFunc3<TArg0, TArg1, TArg2, TResult = void> = (arg0: TArg0, arg1: TArg1, arg2: TArg2) => Promise<TResult>;
export type AsyncFunc4<TArg0, TArg1, TArg2, TArg3, TResult = void> = (
    arg0: TArg0,
    arg1: TArg1,
    arg2: TArg2,
    arg3: TArg3,
) => Promise<TResult>;

export type KeyValuePair<TKey, TValue> = {
    key: TKey;
    value: TValue;
};

export type PendingError = {
    pending: boolean;
    error: string | null;
};

export type CommandStatus = {
    count: number;
    error: string | null;
    refresh?: boolean;
};

export type PendingErrorData<TData> = {
    data: TData;
} & CommandStatus;

export type PendingErrorBaseProps = {
    pending: boolean;
    error: string | null;
};

export type AtLeastOne<T, U = { [K in keyof T]: Pick<T, K> }> = Partial<T> & U[keyof U];

export enum SortOrder {
    Asc = "asc",
    Desc = "desc",
}
