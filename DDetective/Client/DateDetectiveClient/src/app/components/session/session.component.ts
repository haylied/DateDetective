import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { SessionService } from '../../services/session.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-session',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './session.component.html',
  styleUrls: ['./session.component.scss']
})
export class SessionComponent implements OnInit{
  sessionForm!: FormGroup;
  appName = 'DateDetective';
  sessionToken: string | null = null;

  constructor(
    private fb: FormBuilder, 
    private http: HttpClient,
    private sessionService: SessionService
  ) {
    this.sessionForm= this.fb.group({
      sessionToken:['', Validators.required]
    });
    }

  ngOnInit(): void {}

  submitSessionToken(): void {
    if (this.sessionForm.valid) {
      const token: string = this.sessionForm.get('sessionToken')?.value;
      console.log('Fetching session for token:', token);

      this.sessionService.getSessionByToken(token).subscribe(
        (sessionData: any) => {
          console.log('Session fetched:', sessionData);
          alert(`Session details: ${JSON.stringify(sessionData)}`);
        }
      );
    }
  }

    onCreateSession(): void {
      this.sessionService.createSession().subscribe(
        (sessionData: any) => {
          // Log the raw sessionToken value to inspect its structure
          console.log('Session created:', sessionData);
          console.log('SessionToken:', sessionData.sessionToken);
          
          // JSON.stringify to see structure
          //alert(`Session token: ${JSON.stringify(sessionData.sessionToken)}`);
    
          const tokenString = sessionData.sessionToken;
          
          // Update the form control and display the token
          this.sessionForm.patchValue({
            sessionToken: tokenString
          });
          alert(`Your session token is: ${tokenString}`);
        }
      );
    }

    onButtonWorks(): void {
      console.log('Button works.');
    }
/*
  //  !--- this method assumes profileId based on activating new session upon profile page
  newSessionToken(): void {
    // when button is selected, a new session is created w/ a unique session token
    // grab session token from database and display on page (latest created session)
  }
*/
}
