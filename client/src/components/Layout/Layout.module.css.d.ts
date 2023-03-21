declare namespace LayoutStyleCssNamespace {
    export interface ILayoutStyleCss {
        container: string;
        outlet: string;
    }
}

declare const LayoutStyleCssModule: LayoutStyleCssNamespace.ILayoutStyleCss;

export = LayoutStyleCssModule;