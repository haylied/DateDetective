import { bootstrapApplication } from '@angular/platform-browser';
//import { AppComponent } from './app/app.component';  // Your main app component
import { EventFormComponent } from './app/event-form/event-form.component';  // Import the standalone component

bootstrapApplication(EventFormComponent, appConfig)
  .catch((err) => console.error(err)); 
import { appConfig } from './app/app.config';  // Configuration if needed

/*bootstrapApplication(AppComponent, appConfig)
  .catch((err) => console.error(err));*/
