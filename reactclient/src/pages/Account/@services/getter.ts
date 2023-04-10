import {AppState} from "../../../store";

export const selector = (s: AppState) => ({
    firstName: s.aspirant.aspirant.firstName,
    secondName: s.aspirant.aspirant.secondName,
    patronymic: s.aspirant.aspirant.patronymic,
    gender: s.aspirant.aspirant.gender,
    dateOfBirth: s.aspirant.aspirant.dateOfBirth,
    phoneNumber: s.aspirant.aspirant.phoneNumber,
    education: s.aspirant.aspirant.education,
    institute: s.aspirant.aspirant.institute,
    department: s.aspirant.aspirant.department,
    scientificSpeciality: s.aspirant.aspirant.scientificSpeciality,
    formOfStudy: s.aspirant.aspirant.formOfStudy,
    budgetForm: s.aspirant.aspirant.budgetForm,
    studyStatus: s.aspirant.aspirant.studyStatus,
});