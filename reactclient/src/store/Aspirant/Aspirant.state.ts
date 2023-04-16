import {AspirantType, PublicationItem} from "./Aspirant.types";

export type AspirantState = {
    aspirant: AspirantType;
    publications: PublicationItem[];
};

export const initState: AspirantState = {
    aspirant: {
        id: 0,
        firstName: "",
        secondName: "",
        gender: "",
        dateOfBirth: "",
        phoneNumber: "",
        scientificSpeciality: "",
        formOfStudy: "",
        budgetForm: "",
        studyStatus: "",
        education: "",
        patronymic: "",
        institute: {
            id: 0,
            name: "",
            cypher: "",
        },
        department: {
            id: 0,
            name: "",
            cypher: "",
        },
    },
    publications: [],
};
