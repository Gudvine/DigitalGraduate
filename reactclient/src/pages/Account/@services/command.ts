import {dispatch} from "../../../store";
import {actions} from "../../../store/Aspirant";

export const loadAspirantData = async (): Promise<void> => {
    const response = await fetch("https://localhost:7267/getStudent/1");
    const res = await response.json();
    console.log(res);

    //@ts-ignore
    dispatch(actions.setAspirantData(res));
}