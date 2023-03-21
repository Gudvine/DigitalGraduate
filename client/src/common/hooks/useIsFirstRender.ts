import { useEffect, useState } from "react";

export const useIsFirstRender = (): boolean => {
    const [isFirstRender, setIsFirstRender] = useState<boolean>(true);

    useEffect(() => {
        setIsFirstRender(false);
    }, []);

    return isFirstRender;
};
