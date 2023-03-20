declare namespace SearchStyleCssNamespace {
    export interface ISearchStyleCss {
        container: string;
        input: string;
        buttonFilter: string;
        buttonSearch: string;
    }
}

declare const SearchStyleCssModule: SearchStyleCssNamespace.ISearchStyleCss;

export = SearchStyleCssModule;