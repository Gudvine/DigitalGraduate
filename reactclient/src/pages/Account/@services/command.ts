import {dispatch} from "../../../store";
import {actions} from "../../../store/Aspirant";

export const loadAspirantData = async (): Promise<void> => {
    const response = await fetch("");
    const responseData = await response.json();

    dispatch(actions.setAspirantData(responseData));
}