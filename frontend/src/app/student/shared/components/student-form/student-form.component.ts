import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { bornDateValidator } from 'src/app/shared/validators/born-date.validator';
import { Data } from 'src/app/student/student-dialog/Models/data.models';
import { EActionStudent } from '../../enumerations/EActionStudent';
import { EStudent } from '../../enumerations/EStudent';
import { Student } from '../../student.model';

@Component({
  selector: 'app-student-form',
  templateUrl: './student-form.component.html',
  styleUrls: ['./student-form.component.scss']
})
export class StudentFormComponent implements OnInit {

  private _data: Data;
  @Input()
  public get data(): Data {
    return this._data;
  }
  public set data(value: Data) {
    this._data = value;
    this.formGroup = this._createForm(this._data.student, this.data.type)
  }
  public formGroup: FormGroup;
  public readonly EnumScholarity = EStudent

  public get getFormValue(): Student | null {
    if (this.formGroup.valid) {
      const formValue: Student = this.formGroup.getRawValue();
      return formValue;
    } else {
      this.showValidationMessage(this.formGroup);
      return null;
    }
  }

  constructor() { }

  ngOnInit(): void {
  }

  private _createForm(student: Student | null = null, type: EActionStudent | null = null): FormGroup {
    return new FormGroup({
      'id': new FormControl({ value: student && student.id ? student.id : '', disabled: type == EActionStudent.toSee }),
      'name': new FormControl({ value: student && student.name ? student.name : '', disabled: type == EActionStudent.toSee }, [Validators.required]),
      'lastName': new FormControl({ value: student && student.lastName ? student.lastName : '', disabled: type == EActionStudent.toSee }, [Validators.required]),
      'email': new FormControl({ value: student && student.email ? student.email : '', disabled: type == EActionStudent.toSee }, [Validators.required, Validators.email]),
      'bornDate': new FormControl({ value: student && student.bornDate ? student.bornDate : '', disabled: type == EActionStudent.toSee }, [Validators.required, bornDateValidator]),
      'scholarity': new FormControl({ value: student && student.scholarity ? student.scholarity : '', disabled: type == EActionStudent.toSee }, [Validators.required])
    });
  }

  public showValidationMessage(formGroup: FormGroup) {

    for (const key in formGroup.controls) {
      if (formGroup.controls.hasOwnProperty(key)) {
        const control: FormControl = <FormControl>formGroup.controls[key];

        if (Object.keys(control).includes('controls')) {
          const formGroupChild: FormGroup = <FormGroup>formGroup.controls[key];
          this.showValidationMessage(formGroupChild);
        }

        control.markAsTouched();
      }
    }
  }


}
