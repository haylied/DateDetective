import { Component, OnInit } from '@angular/core';
import { FormControl, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-event-form',
  standalone: true,
  templateUrl: './event-form.component.html',
  styleUrls: ['./event-form.component.scss']

})
export class EventFormComponent implements OnInit {
  eventForm : FormGroup;
  //eventForm: FormControl;
  appName = 'DateDetective';

  constructor(private fb: FormBuilder) {
    // Form controls: note  startDateTime and endDateTime are each one control
    this.eventForm = this.fb.group({
      eventName: ['', [Validators.required, Validators.minLength(3)]],
      eventDescription: ['', Validators.required],
      allDayEvent: [false, Validators.required],
      startDate: ['', Validators.required],
      startTime: ['', Validators.required], 
      endDate: ['', Validators.required],
      endTime: ['', Validators.required]
    });
  }

  ngOnInit(): void {}

  // allDaySelected(): void{
  //   this.eventForm = this.fb.group({
  //     startDate:,
  //     startTime:,
  //     endDate:,
  //     endTime:['', Validators.required]
  //   });
  // }

  // submitForm(): void {
  //   if (this.eventForm.valid) {
  //     console.log(this.eventForm.value);

  //   }
  // }
}
