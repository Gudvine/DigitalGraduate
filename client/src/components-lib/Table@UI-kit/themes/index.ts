import portalGreyThemeStyles from "./PortalGrey.style.css";
import wikiBlueThemeStyles from "./WikiBlue.style.css";

export type ThemeNames = "wiki-blue" | "portal-grey";

type ThemeStyles = {
    headerRow: string;
    table: string;
    tableHeader: string;
    tableRow: string;
    tableRowActive: string;
};

export const themes: { [theme in ThemeNames]: ThemeStyles } = {
    "wiki-blue": wikiBlueThemeStyles,
    "portal-grey": portalGreyThemeStyles,
};

export const getTheme = (theme: ThemeNames): ThemeStyles => {
    return themes[theme];
};
