declare namespace AppStyleCssNamespace {
    export interface IAppStyleCss {
        container: string;
        title: string;
        functionalButtons: string;
        account: string;
        sidebar: string;
        content: string;
        link: string;
        linkActive: string;
    }
}

declare const AppStyleCssModule: AppStyleCssNamespace.IAppStyleCss;

export = AppStyleCssModule;