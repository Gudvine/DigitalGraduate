import {AppState} from "../../../store";

export const selector = (s: AppState) => ({
    publications: s.aspirant.publications,
});