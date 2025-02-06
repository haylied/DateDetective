import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';  // Your main app component
//import { appConfig } from './app/app.config'; 
import { EventFormComponent } from './app/components/event-form/event-form.component'; 
import { UserAccountComponent } from './app/components/user-accounts/user-accounts.component'; // Import the standalone component

bootstrapApplication( AppComponent)
  .catch((err) => console.error(err)); 
 //import { appConfig } from './app/app.config';  // Configuration if needed

// bootstrapApplication(AppComponent, appConfig)
//   .catch((err) => console.error(err));
