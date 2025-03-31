import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
  })

  export class SessionService {

    // Replace with your backend API URL
    private apiUrl = 'http://localhost:16725';
  
    constructor(private http: HttpClient) { }
  
    createSessionAndProfile(): Observable<any> {
      // Modify the payload if your backend requires additional data
      const payload = {
        // example: user: { name: 'New User', ... }
      };
      return this.http.post(`${this.apiUrl}/session`, payload);
    }
  }