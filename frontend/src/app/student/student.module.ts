import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { StudentComponent } from './student.component';
import { StudentTableComponent } from './student-table/student-table.component';
import { StudentFormComponent } from './shared/components/student-form/student-form.component';
import { StudentDialogComponent } from './student-dialog/student-dialog.component';
import { StudentRoutingModule } from './student-routing.module';

import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';




@NgModule({
  declarations: [
    StudentComponent,
    StudentTableComponent,
    StudentFormComponent,
    StudentDialogComponent
  ],
  imports: [
    CommonModule,
    StudentRoutingModule,
    HttpClientModule,
    MatTableModule,
    MatIconModule,
    MatButtonModule,
    MatDialogModule,
    MatInputModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    FormsModule,
    ReactiveFormsModule,
  ]
})
export class StudentModule { }
