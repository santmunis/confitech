import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Student } from '../shared/student.model';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-student-table',
  templateUrl: './student-table.component.html',
  styleUrls: ['./student-table.component.scss']
})
export class StudentTableComponent implements OnInit {

  @Input() students: Student[] = [];
  @Output() toSeeStudent = new EventEmitter<Student>();
  @Output() updateStudent = new EventEmitter<Student>();
  @Output() deleteStudent = new EventEmitter<Student>();

  public readonly displayedColumns: string[] = ['name', 'lastName', 'bornDate', 'action'];
  constructor() { }

  ngOnInit(): void {
  }

}
