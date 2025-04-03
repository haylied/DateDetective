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
  //   // Use subscribe to handle the observable returned by createSession().
  //   this.sessionService.createSession().subscribe(
  //     (sessionData: any) => {

  //       // Assume the backend returns an object with a sessionToken property
  //       // this.sessionToken = sessionData.sessionToken;


  //       //alert(`Your session token is: ${sessionData.SessionToken}`);
  //       // Expecting the backend to return an object with SessionToken
  //       this.sessionForm.patchValue({
  //         sessionToken: sessionData.SessionToken
  //       });
  //       //console.log(sessionData.sessionToken);
        
  //       console.log('Session created:', sessionData);
  //       alert(`Your session token is: ${sessionData.SessionToken}`);
  //     }
  //   );}

    onCreateSession(): void {
      this.sessionService.createSession().subscribe(
        (sessionData: any) => {
          // Use camelCase property names as returned by the API
          this.sessionForm.patchValue({
            sessionToken: sessionData.sessionToken
          });
          console.log('Session created:', sessionData);
          alert(`Your session token is: ${sessionData.sessionToken}`);
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
