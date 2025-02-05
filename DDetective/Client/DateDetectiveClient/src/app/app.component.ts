import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { EventFormComponent } from './event-form/event-form.component';  


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})

export class AppComponent {
  title = 'DateDetectiveClient';
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
