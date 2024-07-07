import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment.development';
import { TicketTypeResponseDto } from './ticket.service';

@Injectable({
  providedIn: 'root'
})
export class TicketTypeService {
  private apiUrl = `${environment.GymAPI}/tickettypes`;

  constructor(private http: HttpClient) {}

  getAllTicketTypes(): Observable<TicketTypeResponseDto[]> {
    return this.http.get<TicketTypeResponseDto[]>(this.apiUrl);
  }
}

