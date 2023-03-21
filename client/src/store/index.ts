import { configureStore } from "@reduxjs/toolkit";
import { combineReducers } from "redux";
import {departments} from "./Departments";

export const rootReducer = combineReducers({
    departments,
});

export const store = configureStore({
    reducer: rootReducer,
    middleware: (getDefaultMiddleware) =>
        getDefaultMiddleware({
            thunk: false,
            serializableCheck: false,
        }),
});

export const dispatch = store.dispatch;
export const getState = (): AppState => store.getState();

export type AppState = ReturnType<typeof rootReducer>;
