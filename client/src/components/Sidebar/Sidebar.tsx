import React from "react";

import styles from "./Sidebar.module.css"
import {SidebarLink} from "./SidebarLink";
import {SidebarMain} from "./SidebarMain";
import {CalendarIcon} from "../../icons/CalendarIcon";
import {UsersIcon} from "../../icons/UsersIcon";
import {NoteIcon} from "../../icons/NoteIcon";
import {StatisticsIcon} from "../../icons/StatisticsIcon";
import {ListIcon} from "../../icons/ListIcon";
import {StormIcon} from "../../icons/StormIcon";
import {SpeakerIcon} from "../../icons/SpeakerIcon";

export const Sidebar: React.FC = () => {

    return (
        <aside className={styles.container}>
            <SidebarMain />
            <SidebarLink to={"/events"} title={"Мероприятия"} icon={<CalendarIcon />} />
            <SidebarLink to={"/employees"} title={"Сотрудники"} icon={<UsersIcon />} />
            <SidebarLink to={"/notes"} title={"Заметки"} icon={<NoteIcon />} />
            <SidebarLink to={"/statistics"} title={"Статистика"} icon={<StatisticsIcon />} />
            <SidebarLink to={"/fertilizer"} title={"Удобрения"} icon={<ListIcon />}/>
            <SidebarLink to={"/weather"} title={"Погода"} icon={<StormIcon />} />
            <SidebarLink to={"/organizations"} title={"Организации"} icon={<SpeakerIcon />} />
        </aside>
    )
}