import { Component, OnInit  } from '@angular/core';
import { ApiService, Reservation, Payment  } from '../../core/services/api.service';
import { AuthService } from '../../core/services/auth.service';


@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrl: './user-profile.component.scss'
})
export class UserProfileComponent {
  reservations: Reservation[] = [];
  payments: Payment[] = [];
  userId: string | null = null;

  constructor(private apiService: ApiService, private authService: AuthService) {
    this.authService.user$.subscribe(user => {
      this.userId = user ? user.id : null;
    });

  }
  data(): void {
    if (this.userId) {
      this.apiService.getUserReservations(this.userId).subscribe((data: Reservation[]) => {
        this.reservations = data;
      });

      this.apiService.getUserPayments(this.userId).subscribe((data: Payment[]) => {
        this.payments = data;
      });
    }
  }
}
