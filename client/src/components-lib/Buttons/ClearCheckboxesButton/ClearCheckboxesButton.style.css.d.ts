declare namespace ClearCheckboxesButtonStyleCssNamespace {
    export interface IClearCheckboxesButtonStyleCss {
        clearCheckboxButton: string;
        clearCheckboxButtonHidden: string;
        clearCheckboxButtonText: string;
    }
}

declare const ClearCheckboxesButtonStyleCssModule: ClearCheckboxesButtonStyleCssNamespace.IClearCheckboxesButtonStyleCss & {
    /** WARNING: Only available when `css-loader` is used without `style-loader` or `mini-css-extract-plugin` */
    locals: ClearCheckboxesButtonStyleCssNamespace.IClearCheckboxesButtonStyleCss;
};

export = ClearCheckboxesButtonStyleCssModule;
