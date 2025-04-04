import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { EventFormComponent } from './components/event-form/event-form.component';  
import { UserAccountsComponent } from './components/user-accounts/user-accounts.component';
import { SessionComponent } from './components/session/session.component';
import { ProfileComponent } from './components/profile/profile.component';
//import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, EventFormComponent, UserAccountsComponent, SessionComponent, ProfileComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})

export class AppComponent {
  //title = 'DateDetectiveClient';
}