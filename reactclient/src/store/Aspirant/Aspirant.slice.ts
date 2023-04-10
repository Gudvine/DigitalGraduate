import {createSlice, PayloadAction} from "@reduxjs/toolkit";

import {AspirantType, initState} from "./Aspirant.state";

const slice = createSlice({
    name: "aspirant",
    initialState: initState,
    reducers: {
        setAspirantData(state, action: PayloadAction<AspirantType>) {
            state.aspirant = action.payload;
        },
    },
});

export const actions = slice.actions;
export const aspirant = slice.reducer;
