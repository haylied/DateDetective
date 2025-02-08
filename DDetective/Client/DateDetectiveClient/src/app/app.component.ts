import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { EventFormComponent } from './components/event-form/event-form.component';  
import { UserAccountsComponent } from './components/user-accounts/user-accounts.component';


@Component({
  selector: 'app-root',
  //standalone: true,
  imports: [CommonModule, EventFormComponent, UserAccountsComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})

export class AppComponent {
  //title = 'DateDetectiveClient';
}

// @Component({
//   selector: 'app-root',
//   standalone: true,
//   imports: [EventFormComponent],  // Add EventFormComponent as a child of AppComponent
//   template: `<h1>Welcome to {{ appName }}</h1>
//              <app-event-form></app-event-form>`,  // Use EventFormComponent inside AppComponent's template
// })
// export class AppComponent {
//   appName = 'Event Manager';  // Example property
// }
