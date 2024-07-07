// src/app/services/club.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ClubResponseDto } from '../interface/club';
import { environment } from '../../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ClubService {

  private apiUrl = 'https://localhost:7070/api';

  constructor(private http: HttpClient) { }

  getClubs(): Observable<ClubResponseDto[]> {
    return this.http.get<ClubResponseDto[]>(`${this.apiUrl}/clubs`);
  }
}
