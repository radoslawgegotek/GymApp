import { Component } from '@angular/core';

@Component({
  selector: 'app-tickets',
  templateUrl: './tickets.component.html',
  styleUrl: './tickets.component.scss'
})
export class TicketsComponent {
  slides = [
    { title: 'przyklad 1', description: 'Opis biletu ' },
    { title: 'przyklad 2', description: 'Opis biletu ' },
    { title: 'przyklad 3', description: 'Opis biletu ' }
  ];

  selectedTicketType: string = 'A';
  price: string = '100 PLN';

  updatePrice() {
    switch (this.selectedTicketType) {
      case '1':
        this.price = '100 PLN';
        break;
      case '2':
        this.price = '150 PLN';
        break;
      case '3':
        this.price = '200 PLN';
        break;
    }
  }
}

