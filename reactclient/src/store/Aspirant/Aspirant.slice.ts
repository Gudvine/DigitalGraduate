import {createSlice, PayloadAction} from "@reduxjs/toolkit";

import {initState} from "./Aspirant.state";
import {AspirantType, PublicationItem} from "./Aspirant.types";

const slice = createSlice({
    name: "aspirant",
    initialState: initState,
    reducers: {
        setAspirantData(state, action: PayloadAction<AspirantType>) {
            state.aspirant = action.payload;
        },
        setPublicationsData(state, action: PayloadAction<PublicationItem[]>) {
            state.publications = action.payload;
        },
    },
});

export const actions = slice.actions;
export const aspirant = slice.reducer;
