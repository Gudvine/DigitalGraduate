declare namespace TableStyleCssNamespace {
    export interface ITableStyleCss {
        container: string;
        table: string;
    }
}

declare const TableStyleCssModule: TableStyleCssNamespace.ITableStyleCss;

export = TableStyleCssModule;
