import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment.development';

export interface TicketTypeResponseDto {
  id: number;
  name: string;
  description: string;
}


@Injectable({
  providedIn: 'root'
})
export class TicketService {
  private apiUrl = 'https://localhost:7070/api/TicketType';
  constructor(private http: HttpClient) { }

  getTicketTypes(): Observable<TicketTypeResponseDto[]> {
    return this.http.get<TicketTypeResponseDto[]>(this.apiUrl);
  }
}

