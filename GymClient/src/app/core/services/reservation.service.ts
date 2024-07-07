import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from '../../../environments/environment.development';

export interface Class {
    id: number;
    name: string;
    description: string;
    slots: number;
    start: Date;
    end: Date;
  }
  
  
  export interface Club {
    id: number;
    name: string;
    city: string;
  }
  

@Injectable({
  providedIn: 'root'
})
export class ReservationService {
  
  private apiUrl = 'https://localhost:7070/api';
  constructor(private http: HttpClient) { }


  getClassesByClubId(clubId: number): Observable<Class[]> {
    return this.http.get<Class[]>(`${this.apiUrl}/Classes/Club/${clubId}`);
  }

  reserveClass(reservation: { userId: string, classId: number }): Observable<any> {
    return this.http.post(`${this.apiUrl}/reservations`, reservation);
  }

  getClubs(): Observable<Club[]> {
    return this.http.get<Club[]>(`${this.apiUrl}/Clubs`);
  }

  getUserReservations(userId: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/reservations/user?userId=${userId}`);
  }

  updateClass(updatedClass: Class): Observable<Class> {
    return this.http.put<Class>(`${this.apiUrl}/classes/${updatedClass.id}`, updatedClass);
  }
}



