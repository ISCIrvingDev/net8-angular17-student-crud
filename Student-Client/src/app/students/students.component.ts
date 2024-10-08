import { Component, inject, OnInit } from '@angular/core';
import { StudentsService } from '../services/students.service';
import { Student } from '../types/student';
import { Observable } from 'rxjs';
import { AsyncPipe, CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-students',
  standalone: true,
  imports: [AsyncPipe, CommonModule, RouterLink],
  templateUrl: './students.component.html',
  styleUrl: './students.component.css'
})
export class StudentsComponent implements OnInit {
  studentService = inject(StudentsService);

  students$!: Observable<Student[]>;

  ngOnInit(): void {
    // this.studentService.getStudets().subscribe({
    //   next: (res) => {
    //     console.log(res);
    //   },
    //   error: (err) => {
    //     console.log(err);
    //   }
    // });

    this.students$ = this.studentService.getStudets();
  }
}
