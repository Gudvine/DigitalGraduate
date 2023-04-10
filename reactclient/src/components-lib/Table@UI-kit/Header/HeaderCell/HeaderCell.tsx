import React from "react";

import { invertSortOrder } from "../../../../utils/invertSortOrder";

import styles from "./HeaderCell.module.css";
import { SortOrder } from "../../../../common/types";
import { ArrowSortDownIcon } from "../../../Icons@UI-kit/ArrowSortDownIcon";
import { styler } from "../../../../utils/styler";

type HeaderCellProps = {
  Title: JSX.Element;
  sortField?: string;
  sortBy?: string;
  sortOrder?: SortOrder;
  onSort?: (sortBy: string | null, sortOrder: SortOrder) => void;
  Icon?: React.FC<{ isArrowRotated: boolean }>;
  arrowPosition?: "left" | "right";
  customStyles?: React.CSSProperties;
  title?: string;
};

export const HeaderCell: React.FC<HeaderCellProps> = (
  props: HeaderCellProps
) => {
  const {
    sortField = null,
    sortBy,
    sortOrder,
    onSort,
    Icon,
    Title,
    arrowPosition = "right",
  } = props;

  const onSortClick = (): void => {
    const updatedSortOrder: SortOrder =
      sortBy === sortField ? invertSortOrder(sortOrder) : SortOrder.Asc;

    onSort?.(sortField, updatedSortOrder);
  };

  const isArrowRotated = (field: string): boolean =>
    sortBy === field && sortOrder === SortOrder.Asc;

  const renderArrow = (): JSX.Element | null => {
    return sortField !== null ? (
      sortField === sortBy ? (
        // @ts-ignore
        <Icon isArrowRotated={isArrowRotated(sortField)} />
      ) : (
        <ArrowSortDownIcon />
      )
    ) : null;
  };

  return (
    <li
      className={styler(styles.headerRowItem, [
        sortField !== null,
        styles.headerRowItemWithSorting,
      ])}
      onClick={onSortClick}
      style={props.customStyles}
      title={props.title}
    >
      <>{Title}</>
      {arrowPosition === "right" && renderArrow()}
    </li>
  );
};
