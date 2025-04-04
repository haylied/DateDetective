import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ProfileService } from '../../services/profile.services';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit{
  profileForm!: FormGroup;
  appName = 'DateDetective';

  constructor(
    private fb: FormBuilder, 
    private http: HttpClient,
    private profileService: ProfileService
  ) {
    this.profileForm= this.fb.group({
      profileName:['', Validators.required]
    });
    }

  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }
}
