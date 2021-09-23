import { FormControl } from "@angular/forms";

export function bornDateValidator(control: FormControl) {
    let date = control.value;
    if (date) {
        if (date >= new Date()) {
            return {
                bornDate: {
                    date: date
                }
            }
        }
    }
    return null;
}