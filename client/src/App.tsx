import React, { useState } from "react";

import styles from "./App.module.css";
import { PlusIcon } from "./components-lib/Icons@UI-kit/PlusIcon";
import { Button } from "./components-lib/Buttons/Button@UI-kit/Button";
import { Checkbox } from "./components-lib/Checkbox";
import { Counter } from "./components-lib/Counters";
import { ImageLoader } from "./components-lib/ImageLoader";
import { Table } from "./components-lib/Table@UI-kit";
import { DownloadIcon } from "./components-lib/Icons@UI-kit/DownloadIcon";
import { Loader } from "./components-lib/Loaders";
import { Spinner } from "./components-lib/Spinner";

function App() {
  const [value, setValue] = useState<string>("");

  const changeValue = (image: string): void => {
    setValue(image);
  };

  const columns = [
    {
      gridColumnSize: "1fr",
      header: <div>{"test"}</div>,
      cellBuilder: (item: any) => <div>{"test"}</div>,
    },
    {
      gridColumnSize: "1fr",
      header: <div>{"test2"}</div>,
      cellBuilder: (item: any) => <div>{"test"}</div>,
    },
  ];

  const items = [{}];

  return (
    <div className={styles.container}>
      <Loader scale={1} />
      {/*<Table columns={columns} items={items} pending={false} error={null} />*/}
    </div>
  );
}

export default App;
