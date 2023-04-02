declare namespace AccountStyleCssNamespace {
    export interface IAccountStyleCss {
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

declare const AccountStyleCssModule: AccountStyleCssNamespace.IAccountStyleCss;

export = AccountStyleCssModule;