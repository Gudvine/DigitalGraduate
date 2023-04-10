declare namespace PendingErrorGuardStyleCssNamespace {
    export interface IPendingErrorGuardStyleCss {
        containerPending: string;
        errorContainer: string;
        errorText: string;
    }
}

declare const PendingErrorGuardStyleCssModule: PendingErrorGuardStyleCssNamespace.IPendingErrorGuardStyleCss;

export = PendingErrorGuardStyleCssModule;
