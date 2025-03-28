import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-session',
  standalone: true,
  imports: [],
  templateUrl: './session.component.html',
  styleUrl: './session.component.scss'
})
export class SessionComponent implements OnInit{
  sessionForm!: FormGroup;
  appName = 'DateDetective';

  constructor(private fb: FormBuilder)
  {
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
}


