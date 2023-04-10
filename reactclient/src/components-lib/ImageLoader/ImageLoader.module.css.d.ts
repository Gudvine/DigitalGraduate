declare namespace ImageLoaderStyleCssNamespace {
    export interface IImageLoaderStyleCss {
        cross: string;
        crossButton: string;
        crossButtonHidden: string;
        form: string;
        image: string;
        imageBlock: string;
        imageBlockHidden: string;
        imageLoaderTitle: string;
        imageLoaderWrapper: string;
        imageLoaderWrapperDisabled: string;
        imageWrapper: string;
        imageWrapperDisabled: string;
        input: string;
        loaderBlock: string;
        loaderBlockHidden: string;
    }
}

declare const ImageLoaderStyleCssModule: ImageLoaderStyleCssNamespace.IImageLoaderStyleCss;

export = ImageLoaderStyleCssModule;
