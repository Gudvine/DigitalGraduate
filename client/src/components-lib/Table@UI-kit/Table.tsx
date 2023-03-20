import React, { useRef } from "react";

import { Header } from "./Header";
import { Row } from "./Row";
import { OptionalEntityFields } from "./Row/Row";
import { Stub } from "./Stub";
import { getTheme, ThemeNames } from "./themes";

import styles from "./Table.style.css";
import { styler } from "../../utils/styler";
import { OptionalGroupFields, TableGroup } from "./TableGroup/TableGroup";
import { PendingErrorGuard } from "../PendingErrorGuard";
import { PendingError } from "../../common/types";

export type TableColumn<T> = {
  gridColumnSize: string;
  header: JSX.Element;
  cellBuilder: (item: T) => JSX.Element;
};

type TableProps<T> = {
  columns: TableColumn<T>[];
  items: (T & OptionalEntityFields)[];
  groups?: OptionalGroupFields<T>[];
  stubTitle?: string;
  tableWrapperStyles?: React.CSSProperties;
  theme?: ThemeNames;
  activeItemId?: string | null;
  lastCreatedEditableItemId?: string | null;
  hasEditableItem?: boolean;
} & PendingError;

export const Table = <T extends { [key: string]: unknown }>(
  props: TableProps<T>
): JSX.Element => {
  const { columns, tableWrapperStyles, stubTitle, pending, error } = props;

  const themeStyles = getTheme(props.theme ?? "portal-grey");

  const scrollableListRef = useRef<HTMLDivElement>(null);
  const activeItemRef = useRef(null);

  const showStub =
    props.groups !== undefined &&
    props.items.length === 0 &&
    props.groups.length === 0;
  const gridColumns = columns
    .map((column: TableColumn<T>) => column.gridColumnSize)
    .join(" ");

  return (
    <>
      <Header
        headerElements={columns.map((c: TableColumn<T>) => c.header)}
        gridColumns={gridColumns}
        theme={props.theme}
      />
      <div className={styles.container} style={tableWrapperStyles}>
        <PendingErrorGuard
          pending={pending}
          error={error}
          loader={"loader"}
          size={1.4}
        >
          <Stub show={showStub} text={stubTitle ?? "Ничего не найдено"}>
            <div
              className={styler(styles.table, themeStyles.table)}
              ref={scrollableListRef}
            >
              {props.groups !== undefined && props.groups.length > 0 ? (
                <>
                  {props.groups.map((group: OptionalGroupFields<T>) => (
                    <div
                      key={group.id}
                      ref={
                        group.id === props.activeItemId ? activeItemRef : null
                      }
                    >
                      <TableGroup
                        activeItemId={props.activeItemId}
                        title={group.title}
                        id={group.id}
                        rows={group.rows}
                        gridColumns={gridColumns}
                        columns={columns}
                      />
                    </div>
                  ))}
                </>
              ) : (
                <>
                  {props.items.map(
                    (item: T & OptionalEntityFields, i: number) => (
                      <Row
                        key={i}
                        rowCells={columns.map((c: TableColumn<T>) =>
                          c.cellBuilder(item)
                        )}
                        gridColumns={gridColumns}
                        isActive={item.isActive}
                        onClick={item.onClick}
                      />
                    )
                  )}
                </>
              )}
            </div>
          </Stub>
        </PendingErrorGuard>
      </div>
    </>
  );
};
