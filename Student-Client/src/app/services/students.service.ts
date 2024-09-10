import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Student } from '../types/student';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StudentsService {
  private urlApi = 'http://localhost:5279/api';

  constructor(private http: HttpClient) { }

  getStudets = (): Observable<Student[]> => this.http.get<Student[]>(`${this.urlApi}/students`);
}
