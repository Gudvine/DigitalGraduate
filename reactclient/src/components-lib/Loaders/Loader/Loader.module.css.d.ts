declare namespace LoaderStyleCssNamespace {
    export interface ILoaderStyleCss {
        blue: string;
        circle: string;
        dark: string;
        goDown: string;
        goDownAnimation: string;
        goLeft: string;
        goLeftAnimation: string;
        goRight: string;
        goRightAnimation: string;
        goUp: string;
        goUpAnimation: string;
        grey: string;
        greyDark: string;
        noFlick: string;
        square: string;
        template: string;
        white: string;
    }
}

declare const LoaderStyleCssModule: LoaderStyleCssNamespace.ILoaderStyleCss;

export = LoaderStyleCssModule;
