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

export type PublicationItem = {
    title: string;
    edition: string;
    year: string;
    articleType: string;
    consultant: string;
}