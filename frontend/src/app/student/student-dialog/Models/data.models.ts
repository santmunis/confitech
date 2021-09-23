import { EActionStudent } from "../../shared/enumerations/EActionStudent";
import { Student } from "../../shared/student.model";

export interface Data {
    student: Student,
    type: EActionStudent
}