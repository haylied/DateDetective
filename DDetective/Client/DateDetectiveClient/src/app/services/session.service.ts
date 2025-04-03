import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
  })

  

  export class SessionService {

    // Replace with your backend API URL
    private apiUrl = 'http://localhost:5000';
  
    constructor(private http: HttpClient) { }
  
    createSession(): Observable<any> {
        // sends empty object as backend generates the session token
        
        return this.http.post<any>(`${this.apiUrl}/session`, {});

      //return this.http.post(`${this.apiUrl}/session`, {});
    }
  }