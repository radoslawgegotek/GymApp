import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ClassResponseDto } from '../interface/class';

export interface ClassDTO {
  name: string;
  description: string;
  slots: number;
  start: string;
  end: string;
  clubId: number;
}

export interface ClubDTO {
  name: string;
  description: string;
  city: string;
  address: string;
  phoneNumber: string;
}

export interface TicketTypeDTO {
  name: string;
  description: string;
}

export interface ClubTicketTypeDTO {
  clubId: number;
  ticketTypeId: number;
}

export interface Reservation {
  id: number;
  userId: string;
  classId: number;
}

export interface Payment {
  id: number;
  price: number;
  userId: string;
}

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private baseUrl = 'https://localhost:7070/api';

  constructor(private http: HttpClient) {}

  addClass(classData: ClassDTO): Observable<any> {
    return this.http.post(`${this.baseUrl}/Classes`, classData);
  }

  deleteClass(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/Classes/${id}`);
  }

  addClub(clubData: ClubDTO): Observable<any> {
    return this.http.post(`${this.baseUrl}/Clubs`, clubData);
  }

  deleteClub(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/Clubs/${id}`);
  }

  addTicketType(ticketTypeData: TicketTypeDTO): Observable<any> {
    return this.http.post(`${this.baseUrl}/TicketType`, ticketTypeData);
  }

  deleteTicketType(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/TicketType/${id}`);
  }

  addClubTicketType(clubTicketTypeData: ClubTicketTypeDTO): Observable<any> {
    return this.http.post(`${this.baseUrl}/ClubTicketType`, clubTicketTypeData);
  }

  deleteClubTicketType(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/ClubTicketType/${id}`);
  }

  getUserReservations(userId: string): Observable<Reservation[]> {
    return this.http.get<Reservation[]>(`${this.baseUrl}/Reservations/User?userId=${userId}`);
  }

  getUserPayments(userId: string): Observable<Payment[]> {
    return this.http.get<Payment[]>(`${this.baseUrl}/UserPayments/byUserId/${userId}`);
  }

  getClassDetailsById(classId: number): Observable<ClassResponseDto> {
    return this.http.get<ClassResponseDto>(`${this.baseUrl}/Classes/Club/User/${classId}`);
  }
}
