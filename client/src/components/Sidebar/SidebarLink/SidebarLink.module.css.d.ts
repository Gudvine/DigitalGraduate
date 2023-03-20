declare namespace SidebarLinkStyleCssNamespace {
    export interface ISidebarLinkStyleCss {
        container: string;
        active: string;
        link: string;
        icon: string;
    }
}

declare const SidebarLinkStyleCssModule: SidebarLinkStyleCssNamespace.ISidebarLinkStyleCss;

export = SidebarLinkStyleCssModule;