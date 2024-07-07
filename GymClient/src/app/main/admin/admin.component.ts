import { Component } from '@angular/core';
import { ClubDTO, ApiService, ClassDTO, TicketTypeDTO, ClubTicketTypeDTO } from '../../core/services/api.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.scss'
})
export class AdminComponent {
  classData: ClassDTO = {
    name: '',
    description: '',
    slots: 0,
    start: '',
    end: '',
    clubId: 0
  };

  deleteClassId: number = 0;

  clubData: ClubDTO = {
    name: '',
    description: '',
    city: '',
    address: '',
    phoneNumber: ''
  };

  deleteClubId: number= 0;

  ticketTypeData: TicketTypeDTO = {
    name: '',
    description: ''
  };

  deleteTicketTypeId: number= 0;

  clubTicketTypeData: ClubTicketTypeDTO = {
    clubId: 0,
    ticketTypeId: 0
  };

  deleteClubTicketTypeId: number= 0;

  constructor(private apiService: ApiService) {}

  addClass() {
    this.apiService.addClass(this.classData).subscribe(response => {
      alert('Class added');
    });
  }

  deleteClass() {
    this.apiService.deleteClass(this.deleteClassId).subscribe(response => {
      alert('Class deleted');
    });
  }

  addClub() {
    this.apiService.addClub(this.clubData).subscribe(response => {
      alert('Club added');
    });
  }

  deleteClub() {
    this.apiService.deleteClub(this.deleteClubId).subscribe(response => {
      alert('Club deleted');
    });
  }

  addTicketType() {
    this.apiService.addTicketType(this.ticketTypeData).subscribe(response => {
      alert('Ticket Type added');
    });
  }

  deleteTicketType() {
    this.apiService.deleteTicketType(this.deleteTicketTypeId).subscribe(response => {
      alert('Ticket Type deleted');
    });
  }

  addClubTicketType() {
    this.apiService.addClubTicketType(this.clubTicketTypeData).subscribe(response => {
      alert('Club Ticket Type added');
    });
  }

  deleteClubTicketType() {
    this.apiService.deleteClubTicketType(this.deleteClubTicketTypeId).subscribe(response => {
      alert('Club Ticket deleted');
    });
  }
}
