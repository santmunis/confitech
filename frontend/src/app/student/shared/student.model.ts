import { EStudent } from "./enumerations/EStudent";

export interface Student {
    id?: number;
    name: string;
    lastName: string;
    email: string;
    bornDate: Date;
    scholarity: EStudent;
}