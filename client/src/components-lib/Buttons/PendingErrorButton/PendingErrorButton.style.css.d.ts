declare namespace PendingErrorButtonStyleCssNamespace {
    export interface IPendingErrorButtonStyleCss {
        dot: string;
        dotBlinking: string;
        pendingContainer: string;
    }
}

declare const PendingErrorButtonStyleCssModule: PendingErrorButtonStyleCssNamespace.IPendingErrorButtonStyleCss & {
    /** WARNING: Only available when `css-loader` is used without `style-loader` or `mini-css-extract-plugin` */
    locals: PendingErrorButtonStyleCssNamespace.IPendingErrorButtonStyleCss;
};

export = PendingErrorButtonStyleCssModule;
