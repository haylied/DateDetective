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
  //profileId = '';

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
    //throw new Error('Method not implemented.');
  }

  onCreateProfile(): void {
    this.profileService.createProfile().subscribe(
      (profileData: any) => {
        console.log('Profile created:', profileData);
        console.log('Profile ID:', profileData.profileId);
      
        const profileId = profileData.profileId;
        
        // Update the form control and display the token
        this.profileForm.patchValue({
          profileId: profileId
        });
        alert(`Profile ID#: ${profileId}`);
      }
    );
  }
}
