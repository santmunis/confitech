import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { EActionStudent } from './shared/enumerations/EActionStudent';
import { Student } from './shared/student.model';
import { StudentService } from './shared/student.service';
import { StudentDialogComponent } from './student-dialog/student-dialog.component';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.scss']
})
export class StudentComponent implements OnInit {

  public students: Student[] = [];
  constructor(private _studentService: StudentService,
    private _dialog: MatDialog,) { }

  ngOnInit(): void {
    this._studentService.getAllStudent().subscribe(value => {
      this.students = value;
    });
  }

  public toSeeStudent(student: Student): void {
    const dialogRef = this.openDialog(student, EActionStudent.toSee);
  }

  public updateStudent(student: Student): void {
    const dialogRef = this.openDialog(student, EActionStudent.update);

    dialogRef.afterClosed().subscribe(value => {
      if (value) {
        this._studentService.updateStudent(value).subscribe((response: Student) => {
          const index = this.students.findIndex(student => response.id === student.id);
          this.students[index] = response;
          this.students = [...this.students];
        });
      }
    });
  }

  public deleteStudent(student: Student): void {
    const id = student.id as number;
    this._studentService.deleteStudent(id).subscribe(() => {
      this.students = this.students.filter(student => student.id !== id);
    });
  }

  public createStudent(): void {
    const dialogRef = this.openDialog(null, EActionStudent.create);

    dialogRef.afterClosed().subscribe(value => {
      if (value) {
        this._studentService.createStudent(value).subscribe((response: Student) => {
          this.students = [...this.students, response];
        });
      }
    });
  }

  public openDialog(data: Student | null, type: EActionStudent) {
    return this._dialog.open(StudentDialogComponent, {
      width: '1000px',
      maxHeight: '90vh',
      data: {
        student: data,
        type: type
      }
    });
  }
}
