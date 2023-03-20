declare namespace ToggleButtonStyleCssNamespace {
    export interface IToggleButtonStyleCss {
        toggleButton: string;
    }
}

declare const ToggleButtonStyleCssModule: ToggleButtonStyleCssNamespace.IToggleButtonStyleCss & {
    /** WARNING: Only available when `css-loader` is used without `style-loader` or `mini-css-extract-plugin` */
    locals: ToggleButtonStyleCssNamespace.IToggleButtonStyleCss;
};

export = ToggleButtonStyleCssModule;
