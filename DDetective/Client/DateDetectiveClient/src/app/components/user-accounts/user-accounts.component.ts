import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { UserService } from '../../services/user.service'; // Make sure you create and configure this service

@Component({
  selector: 'app-user-accounts',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './user-accounts.component.html',
  styleUrls: ['./user-accounts.component.scss']
})

export class UserAccountsComponent implements OnInit {
  userForm!: FormGroup;
  submitted = false;
  successMessage: string = '';
  errorMessage: string = '';

  constructor(private fb: FormBuilder, private userService: UserService) {}

  ngOnInit(): void {
    // Initialize the reactive form with validation rules
    this.userForm = this.fb.group({
      username: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
  }

  onSubmit(): void {
    this.submitted = true;
    // If the form is invalid, stop here
    if (this.userForm.invalid) {
      return;
    }

    // Call the user service to create a new account
    this.userService.createUser(this.userForm.value).subscribe(
      response => {
        this.successMessage = 'User account created successfully!';
        this.errorMessage = '';
        this.userForm.reset();
        this.submitted = false;
      },
      error => {
        this.errorMessage = 'There was an error creating the user account.';
        this.successMessage = '';
      }
    );
  }
}
