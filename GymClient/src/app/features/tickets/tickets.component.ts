import { Component, OnInit } from '@angular/core';
import { TicketService, TicketTypeResponseDto } from '../../core/services/ticket.service';
import { PaymentsService } from '../../core/services/payments.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';



@Component({
	selector: 'app-tickets',
	templateUrl: './tickets.component.html',
	styleUrl: './tickets.component.scss'
})
export class TicketsComponent implements OnInit {

	ticketTypes: TicketTypeResponseDto[] = [];
	selectedDate: Date | null = null;
	dateForm: FormGroup;


	constructor(private ticketService: TicketService, private paymentsService: PaymentsService, private fb: FormBuilder) {
		this.dateForm = this.fb.group({
			date: [null, Validators.required]
		});
	}

	ngOnInit(): void {
		this.ticketService.getTicketTypes().subscribe((data: TicketTypeResponseDto[]) => {
			this.ticketTypes = data;
		});
	}

	createSession(ticketTypeId: number) {
		this.paymentsService.requestMemberSession(ticketTypeId, this.selectedDate!);
	}

  getPrice(ticketTypeId: number): string {
    let basePrice = 100;
    return `${basePrice + ((ticketTypeId - 1) * 20)} PLN`;
  }

  submit() {
    if (this.dateForm.valid) {
      console.log('Wybrana data:', this.selectedDate);
    } else {
      console.log('Formularz jest nieprawidłowy');
    }
  }
}
