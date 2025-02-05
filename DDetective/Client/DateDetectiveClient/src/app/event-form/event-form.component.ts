import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';  // For Angular directives like ngIf, ngFor
import { ReactiveFormsModule, FormBuilder, Validators, FormGroup } from '@angular/forms';  // ReactiveFormsModule for reactive forms
import { AppConfig } from '../app.config';  // Importing the configuration file

@Component({
  selector: 'app-event-form',
  standalone: true,  // standalone component, new to Angular 14 and up
  imports: [CommonModule, ReactiveFormsModule],  // Reactive Module for Scalabillity
  templateUrl: './event-form.component.html',  // Link to HTML template
  styleUrls: ['./event-form.component.scss'],  // Link to SCSS styling
})

export class EventFormComponent {
  // Accessing configuration settings
  appName = AppConfig.appName;
  apiUrl = AppConfig.apiUrl;

  eventForm:  FormGroup;
    

  // Reactive form setup with validation
/*  eventForm = this.formBuilder.group({
    eventName: ['', [Validators.required, Validators.minLength(3)]],  // Event name should be required and at least 3 characters long
    eventDescription: ['', [Validators.required]],  // Event description is required
    startDate: ['', Validators.required],  // Start date is required
    endDate: ['', Validators.required],  // End date is required
  });*/
  
 constructor(private fb: FormBuilder) {
  this.eventForm = this.fb.group({
    eventName: ['', [Validators.required, Validators.minLength(3)]],  // Event name should be required and at least 3 characters long
    eventDescription: ['', [Validators.required]],  // Event description is required
    startDate: ['', Validators.required],  // Start date is required
    endDate: ['', Validators.required],  // End date is required
  });
  }

  // Method to handle form submission
  submitForm() {
    if (this.eventForm.valid) {
      console.log('Form Submitted:', this.eventForm.value);  // Log the form values
    } else {
      console.log('Form is invalid');
    }
  }

  // Getter methods for form controls to easily check validation status in the template
  get eventName() {
    return this.eventForm.get('eventName');
  }

  get eventDescription() {
    return this.eventForm.get('eventDescription');
  }

  get startDate() {
    return this.eventForm.get('startDate');
  }

  get endDate() {
    return this.eventForm.get('endDate');
  }
}
