declare namespace SecondaryGreyStyleCssNamespace {
    export interface ISecondaryGreyStyleCss {
        button: string;
        buttonActive: string;
    }
}

declare const SecondaryGreyStyleCssModule: SecondaryGreyStyleCssNamespace.ISecondaryGreyStyleCss;

export = SecondaryGreyStyleCssModule;
