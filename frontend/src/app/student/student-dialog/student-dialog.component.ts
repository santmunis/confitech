import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { StudentFormComponent } from '../shared/components/student-form/student-form.component';
import { EActionStudent } from '../shared/enumerations/EActionStudent';
import { Data } from './Models/data.models';


@Component({
  selector: 'app-student-dialog',
  templateUrl: './student-dialog.component.html',
  styleUrls: ['./student-dialog.component.scss']
})
export class StudentDialogComponent implements OnInit {

  @ViewChild('form') private _form: StudentFormComponent;
  public get formValues() { return this._form.getFormValue; }
  public buttonLabel: { [key: string]: string } = {
    [EActionStudent.toSee]: "OK",
    [EActionStudent.create]: "Criar Aluno",
    [EActionStudent.update]: "Atualizar Aluno",
  };
  constructor(
    public dialogRef: MatDialogRef<StudentDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Data
  ) {
  }

  ngOnInit(): void {
  }

  public save() {
    if (this.formValues) {
      this.dialogRef.close(this.formValues);
    } else if (this.data.type == EActionStudent.toSee) {
      this.dialogRef.close();
    }
  }
}
