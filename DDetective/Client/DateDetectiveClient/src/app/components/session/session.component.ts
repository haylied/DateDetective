import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SessionService } from '../../services/session.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-session',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './session.component.html',
  styleUrl: './session.component.scss'
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
    if(this.sessionForm.valid)
    {
      //take to events
      console.log(this.sessionForm.value);
    }
  }
    // onCreateSession(): void {
    //   this.sessionService.createSession().subscribe(
    //     (sessionData: any) => {
    //       // Use camelCase property names
    //       this.sessionForm.patchValue({
    //         sessionToken: sessionData.sessionToken
    //       });
    //       console.log('Session created:', sessionData);
    //       alert(`Your session token is: ${sessionData.sessionToken}`);
    //     }
    //   );
    // }

    onCreateSession(): void {
      this.sessionService.createSession().subscribe(
        (sessionData: any) => {
          // Log the raw sessionToken value to inspect its structure
          console.log('Session created:', sessionData);
          console.log('Raw sessionToken:', sessionData.sessionToken);
          
          // JSON.stringify to see structure
          //alert(`Raw session token: ${JSON.stringify(sessionData.sessionToken)}`);
    
          // Assuming after inspection you determine the actual token string is in a property, for example, "token":
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
