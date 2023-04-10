declare namespace LayoutStyleCssNamespace {
    export interface ILayoutStyleCss {
        container: string;
        title: string;
        functionalButtons: string;
        account: string;
        sidebar: string;
        content: string;
        link: string;
        linkActive: string;
        pageContent: string;
    }
}

declare const LayoutStyleCssModule: LayoutStyleCssNamespace.ILayoutStyleCss;

export = LayoutStyleCssModule;