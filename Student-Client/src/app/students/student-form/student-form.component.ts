import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-student-form',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './student-form.component.html',
  styleUrl: './student-form.component.css'
})
export class StudentFormComponent implements OnInit {
  form!: FormGroup;

  /**
   *
   */
  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.form = this.fb.group({
      id: [],
      name: [],
      address: [],
      phoneNumber: [],
      email: []
    });
  }
}
