import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input'
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar'

@Component({
  selector: 'app-signin',
  standalone: true,
  imports: [MatInputModule, RouterLink, MatSnackBarModule, MatIconModule, ReactiveFormsModule],
  templateUrl: './signin.component.html',
  styleUrl: './signin.component.css'
})
export class SigninComponent implements OnInit {
 authService = inject(AuthService);
 matSnackBar = inject(MatSnackBar);
 router = inject(Router)
 hide =  true;
 form!: FormGroup;
 fb = inject(FormBuilder);

 signin(){
  this.authService.signin(this.form.value).subscribe({
    next:(response)=>{
      this.matSnackBar.open(response.message, 'Close',{
        duration:5000,
        horizontalPosition: "center"
      })
      this.router.navigate(['/'])
    },
    error:(error)=>{
      this.matSnackBar.open(error.error.message, 'Close',{
        duration:5000,
        horizontalPosition: "center"
      })
    }
  });
 }

 ngOnInit(): void {
  this.form = this.fb.group({
    email:['', [Validators.required, Validators.email]],
    password: ['', Validators.required]
  })
 }
}
