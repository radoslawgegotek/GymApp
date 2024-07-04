// src/app/services/club.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ClubResponseDto } from '../interface/club';

@Injectable({
  providedIn: 'root'
})
export class ClubService {
  private apiUrl = 'http://localhost:5000/api'; // Zastąp URL odpowiednim adresem API

  constructor(private http: HttpClient) { }

  getClubs(): Observable<ClubResponseDto[]> {
    return this.http.get<ClubResponseDto[]>(`${this.apiUrl}/clubs`);
  }
}
