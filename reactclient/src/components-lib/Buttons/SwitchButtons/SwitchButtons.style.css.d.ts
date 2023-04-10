declare namespace SwitchButtonsStyleCssNamespace {
    export interface ISwitchButtonsStyleCss {
        button: string;
        buttonActive: string;
        buttonLast: string;
        buttonLastVertical: string;
        buttonMiddle: string;
        buttonMiddleVertical: string;
        buttonText: string;
        buttonVertical: string;
        container: string;
        containerVertical: string;
    }
}

declare const SwitchButtonsStyleCssModule: SwitchButtonsStyleCssNamespace.ISwitchButtonsStyleCss & {
    /** WARNING: Only available when `css-loader` is used without `style-loader` or `mini-css-extract-plugin` */
    locals: SwitchButtonsStyleCssNamespace.ISwitchButtonsStyleCss;
};

export = SwitchButtonsStyleCssModule;
