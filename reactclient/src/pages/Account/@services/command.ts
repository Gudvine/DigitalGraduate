import {dispatch} from "../../../store";
import {actions} from "../../../store/Aspirant";

export const loadAspirantData = async (): Promise<void> => {
    const responseBody = await fetch("https://localhost:7267/getStudent/1");
    const responseAsJson = await responseBody.json();

    console.log(responseAsJson);
    //@ts-ignore
    dispatch(actions.setAspirantData(responseAsJson));
}