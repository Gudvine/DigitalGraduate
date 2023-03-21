import React from "react";

import styles from "./TableGroup.style.css";
import { OptionalEntityFields, Row } from "../Row/Row";
import { TableColumn } from "../Table";
import { styler } from "../../../utils/styler";

export type OptionalGroupFields<T> = {
  id: string;
  title: string;
  rows: (T & OptionalEntityFields)[];
};

export type TableGroupProps<T> = {
  columns: TableColumn<T>[];
  gridColumns: string;
  activeItemId: string | null | undefined;
} & OptionalGroupFields<T>;

export const TableGroup = <T extends { [key: string]: unknown }>(
  props: TableGroupProps<T>
): JSX.Element => {
  return (
    <div>
      <div
        className={styler(styles.title, [
          props.activeItemId === props.id,
          styles.titleActive,
        ])}
      >
        {props.title}
      </div>
      <div>
        {props.rows.map((item, i) => (
          <Row
            key={i}
            rowCells={props.columns.map((c) => c.cellBuilder(item))}
            gridColumns={props.gridColumns}
            rowStyles={{ borderTop: "1px solid var(--color-grey-primary)" }}
            isActive={item.isActive}
            onClick={item.onClick}
          />
        ))}
      </div>
    </div>
  );
};
