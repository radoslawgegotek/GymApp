// src/app/services/class.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ClassResponseDto } from '../interface/class';


@Injectable({
  providedIn: 'root'
})
export class ClassService {
  private apiUrl = 'http://localhost:5000/api'; // Zastąp URL odpowiednim adresem API

  constructor(private http: HttpClient) { }

  getClassesByCity(city: string): Observable<ClassResponseDto[]> {
    return this.http.get<ClassResponseDto[]>(`${this.apiUrl}/classes?city=${city}`);
  }

  reserveClass(classId: number): Observable<any> {
    return this.http.post(`${this.apiUrl}/reservations`, { classId });
  }
}
