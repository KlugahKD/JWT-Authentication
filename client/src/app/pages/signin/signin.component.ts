import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input'
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-signin',
  standalone: true,
  imports: [MatInputModule, RouterLink, MatIconModule, ReactiveFormsModule],
  templateUrl: './signin.component.html',
  styleUrl: './signin.component.css'
})
export class SigninComponent implements OnInit {
 hide =  true;
 form!: FormGroup;
 fb = inject(FormBuilder);

 signin(){}

 ngOnInit(): void {
  this.form = this.fb.group({
    email:['', [Validators.required, Validators.email]],
    password: ['', Validators.required]
  })
 }
}
