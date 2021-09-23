import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Student } from './student.model';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private _http: HttpClient) { }

  public getStudentById(id: number): Observable<any> {
    return this._http.get(`${environment.apiUrl}/ByID`, {
      params: {
        "id": id
      }
    });
  }

  public getAllStudent(): Observable<Array<Student>> {
    return this._http.get(`${environment.apiUrl}/student/`) as Observable<Array<Student>>;
  }

  public createStudent(student: Student): Observable<Student> {
    return this._http.post(`${environment.apiUrl}/student/`, student) as Observable<Student>;
  }

  public updateStudent(student: Student): Observable<Student> {
    return this._http.put(`${environment.apiUrl}/student/`, student) as Observable<Student>;
  }

  public deleteStudent(id: number): Observable<boolean> {
    return this._http.delete(`${environment.apiUrl}/student/`, {
      params: {
        "id": id
      }
    }) as Observable<boolean>;
  }
}
