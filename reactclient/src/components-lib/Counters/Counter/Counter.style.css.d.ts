declare namespace CounterStyleCssNamespace {
    export interface ICounterStyleCss {
        counter: string;
        counterTitle: string;
        counterWrap: string;
        text: string;
    }
}

declare const CounterStyleCssModule: CounterStyleCssNamespace.ICounterStyleCss;

export = CounterStyleCssModule;
