import { createSlice } from "@reduxjs/toolkit";

import { initState } from "./Departments.state";

const slice = createSlice({
    name: "departments",
    initialState: initState,
    reducers: {},
});

export const actions = slice.actions;
export const departments = slice.reducer;
