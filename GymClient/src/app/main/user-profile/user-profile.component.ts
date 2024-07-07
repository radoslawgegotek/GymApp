import { Component, OnInit  } from '@angular/core';
import { ApiService, Reservation, Payment  } from '../../core/services/api.service';
import { AuthService } from '../../core/services/auth.service';
import { ClassResponseDto } from '../../core/interface/class';
import { forkJoin } from 'rxjs';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrl: './user-profile.component.scss'
})

export class UserProfileComponent {
  reservations: Reservation[] = [];
  payments: Payment[] = [];
  userId: string | null = null;
  classDetailsMap: { [key: number]: ClassResponseDto } = {};

  constructor(private apiService: ApiService, private authService: AuthService) {
    this.authService.user$.subscribe(user => {
      this.userId = user ? user.id : null;
    });

  }

  data(): void {
    if (this.userId) {
      this.apiService.getUserReservations(this.userId).subscribe((reservations: Reservation[]) => {
        this.reservations = reservations;

        if (reservations.length > 0) {
          const classDetailObservables = reservations.map(reservation =>
            this.apiService.getClassDetailsById(reservation.classId)
          );

          forkJoin(classDetailObservables).subscribe((classDetails: ClassResponseDto[]) => {
            classDetails.forEach(details => {
              this.classDetailsMap[details.id] = details;
            });
          });
        }
      });

      this.apiService.getUserPayments(this.userId).subscribe((data: Payment[]) => {
        this.payments = data;
      });
    }
  }

  getClassDetails(classId: number): ClassResponseDto | undefined {
    return this.classDetailsMap[classId];
  }
}
