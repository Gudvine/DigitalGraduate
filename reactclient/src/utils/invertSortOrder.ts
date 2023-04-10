import { SortOrder } from "./../common/types";

export function invertSortOrder(sortOrder: SortOrder | undefined): SortOrder {
  return sortOrder === SortOrder.Asc ? SortOrder.Desc : SortOrder.Asc;
}
