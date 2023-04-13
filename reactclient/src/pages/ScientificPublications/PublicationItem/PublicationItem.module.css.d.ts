declare namespace PublicationItemStyleCssNamespace {
    export interface IPublicationItemStyleCss {
        container: string;
        publication: string;
        button: string;
        title: string;
        titleBlock: string;
        info: string;
    }
}

declare const PublicationItemStyleCssModule: PublicationItemStyleCssNamespace.IPublicationItemStyleCss;

export = PublicationItemStyleCssModule;