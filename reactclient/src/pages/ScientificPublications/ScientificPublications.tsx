import React, {useEffect} from "react";
import styles from "./ScientificPublications.module.css";
import {loadPublicationsData} from "./@services/command";
import {useSelector} from "react-redux";
import {selector} from "./@services/getters";
import {PublicationItem} from "./PublicationItem";

export const ScientificPublications: React.FC = () => {
    useEffect(() => {
        (async function anyFunc(){
            await loadPublicationsData();
        })();
    }, []);

    const state = useSelector(selector);

    return (
      <div className={styles.container}>
          {
              state.publications.length === 0
                  ?
                  <div>{"Нет публикаций"}</div>
                  :
                  state.publications.map((publication) => {
                      return (
                          <PublicationItem
                              title={publication.title}
                              edition={publication.edition}
                              year={publication.year}
                              articleType={publication.articleType}
                              consultant={publication.consultant} />
                      );
                  })
          }
      </div>
    );
}