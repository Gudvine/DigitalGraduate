import {dispatch} from "../../../store";
import {actions} from "../../../store/Aspirant";

export const loadAspirantData = async (): Promise<void> => {
    const response = await fetch("");

    //@ts-ignore
    dispatch(actions.setAspirantData(response));
}