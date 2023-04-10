declare namespace CheckboxStyleCssNamespace {
    export interface ICheckboxStyleCss {
        checkbox: string;
        checkboxDisabled: string;
        checkboxInput: string;
        container: string;
        icon: string;
        iconChecked: string;
        text: string;
    }
}

declare const CheckboxStyleCssModule: CheckboxStyleCssNamespace.ICheckboxStyleCss;

export = CheckboxStyleCssModule;
