import { useEffect } from "react";
import { useLocation } from "react-router-dom";
import { jsonParseDateReviver } from "../../utils/json";

export const useLocationParams = <T>(clearParams = false): T | null => {
  const location = useLocation();
  // const history = useHistory();

  let searchParams = {};
  if (location.search) {
    const [key, value] = location.search.slice(1).split("=");
    if (key === "jsonParams") {
      searchParams = JSON.parse(decodeURI(value), jsonParseDateReviver);
    }
  }

  const stateParams = location.state ? location.state : {};

  useEffect(() => {
    // if (clearParams) {
    //     history.replace({ pathname: location.pathname });
    // }
  }, []);

  return { ...searchParams, ...(stateParams as object) } as T;
};
