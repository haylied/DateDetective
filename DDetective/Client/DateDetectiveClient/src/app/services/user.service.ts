// src/app/services/user.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'  // Ensures a singleton instance application-wide
})
export class UserService {
  private apiUrl = 'http://localhost:16725'; //  API endpoint

  constructor(private http: HttpClient) {}

  createUser(userData: any): Observable<any> {
    return this.http.post(this.apiUrl, userData);
  }

  // Add other API methods as needed
}
