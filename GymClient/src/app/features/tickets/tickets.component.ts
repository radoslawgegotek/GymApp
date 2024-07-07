import { Component, OnInit } from '@angular/core';
import { TicketService, TicketTypeResponseDto } from '../../core/services/ticket.service';



@Component({
  selector: 'app-tickets',
  templateUrl: './tickets.component.html',
  styleUrl: './tickets.component.scss'
})
export class TicketsComponent implements OnInit {
  ticketTypes: TicketTypeResponseDto[] = [];
  selectedDate: Date | null = null;

  constructor(private ticketService: TicketService) { }

  ngOnInit(): void {
    this.ticketService.getTicketTypes().subscribe((data: TicketTypeResponseDto[]) => { 
      this.ticketTypes = data;
    });
  }

  getPrice(ticketTypeId: number): string {
    let basePrice = 100;
    return `${basePrice + ((ticketTypeId - 1) * 20)} PLN`;
  }
}
