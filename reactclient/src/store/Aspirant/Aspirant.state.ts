//TODO: добавить enums

export type DepartmentType = {
    id: number,
    name?: string
    cypher?: string;
}

export type InstituteType = {
    id: number,
    name?: string
    cypher?: string;
}

export type AspirantType = {
    id: number;
    firstName: string;
    secondName: string;
    gender: string;
    dateOfBirth: string;
    phoneNumber: string;
    scientificSpeciality: string;
    formOfStudy: string;
    budgetForm: string;
    studyStatus: string;
    education: string;
    patronymic?: string;
    institute?: InstituteType;
    department?: DepartmentType;
}

export type AspirantState = {
    aspirant: AspirantType;
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
    }
};
