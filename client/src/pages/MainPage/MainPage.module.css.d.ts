declare namespace MainPageStyleCssNamespace {
    export interface IMainPageStyleCss {
        container: string;
        wrapper: string;
        header: string;
        buttons: string;
        button: string;
    }
}

declare const MainPageStyleCssModule: MainPageStyleCssNamespace.IMainPageStyleCss;

export = MainPageStyleCssModule;