import React from "react";

type PictureIconProps = {
    width?: number;
    height?: number;
};

export const PictureIcon: React.FC<PictureIconProps> = ({ width = 40, height = 40 }) => (
    <svg width={width} height={height} viewBox="0 0 40 40" fill="none" xmlns="http://www.w3.org/2000/svg">
        <g filter="url(#filter0_d)">
            <path
                fillRule="evenodd"
                clipRule="evenodd"
                d="M6.57544 2H31.5996H33.2421H33.4247C34.8471 2 36.0002 3.15306 36.0002 4.57544V27.3338L34.175 29.1589V28.9763L29.7212 33.4301L29.3338 34H6.57544C5.15306 34 4 32.8469 4 31.4246V4.57544C4 3.15306 5.15306 2 6.57544 2Z"
                fill="#D8E2F1"
            />
            <path
                d="M33.4249 29.9095V5.86343C33.4249 5.15225 32.8483 4.57568 32.1371 4.57568H7.86353C7.15234 4.57568 6.57578 5.15225 6.57578 5.86343V30.1371C6.57578 30.8482 7.15234 31.4248 7.86353 31.4248H31.9097L33.4249 29.9095Z"
                fill="#BED8FB"
            />
            <path
                d="M33.4251 22.0442L28.2588 14.6527C27.5668 13.6627 26.101 13.6627 25.409 14.6527L18.7462 24.1851H33.425V22.0442H33.4251Z"
                fill="#365E7D"
            />
            <path
                d="M22.4151 11.0373C23.5267 11.0373 24.4279 10.1362 24.4279 9.02452C24.4279 7.91288 23.5267 7.01172 22.4151 7.01172C21.3034 7.01172 20.4023 7.91288 20.4023 9.02452C20.4023 10.1362 21.3034 11.0373 22.4151 11.0373Z"
                fill="#FFC344"
            />
            <path
                d="M14.0127 11.4032L6.57578 22.0432V23.0219L15.529 24.1842H25.7957L16.8624 11.4032C16.1705 10.4131 14.7046 10.4131 14.0127 11.4032Z"
                fill="#407093"
            />
            <path
                d="M33.4249 29.9106V23.0234H6.57578V30.1381C6.57578 30.8493 7.15234 31.4259 7.86353 31.4259H31.9097L33.4249 29.9106Z"
                fill="#B3E59F"
            />
            <path d="M29.3341 34.0002L36.0003 27.334H31.9095C30.4871 27.334 29.3341 28.487 29.3341 29.9094V34.0002Z" fill="#ACACAC" />
            <path d="M29.3341 34.0002L36.0003 27.334H31.9095C30.4871 27.334 29.3341 28.487 29.3341 29.9094V34.0002Z" fill="#80B4FB" />
        </g>
        <defs>
            <filter id="filter0_d" x="0" y="0" width="40" height="40" filterUnits="userSpaceOnUse" colorInterpolationFilters="sRGB">
                <feFlood floodOpacity="0" result="BackgroundImageFix" />
                <feColorMatrix in="SourceAlpha" type="matrix" values="0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 127 0" />
                <feOffset dy="2" />
                <feGaussianBlur stdDeviation="2" />
                <feColorMatrix type="matrix" values="0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0.25 0" />
                <feBlend mode="normal" in2="BackgroundImageFix" result="effect1_dropShadow" />
                <feBlend mode="normal" in="SourceGraphic" in2="effect1_dropShadow" result="shape" />
            </filter>
        </defs>
    </svg>
);
