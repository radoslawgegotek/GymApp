import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Class, Club, ReservationService } from '../../core/services/reservation.service';
import { AuthService } from '../../core/services/auth.service';
import { switchMap } from 'rxjs/operators';
import { forkJoin } from 'rxjs';

@Component({
  selector: 'app-class-reservation',
  templateUrl: './class-reservation.component.html',
  styleUrl: './class-reservation.component.scss'
})
export class ClassReservationComponent implements OnInit {
  clubs: Club[] = [];
  cities: string[] = [];
  classes: Class[] = [];
  userId: string | null = null;

  constructor(private reservationService: ReservationService, private authService: AuthService) {}

  ngOnInit(): void {
    this.reservationService.getClubs().subscribe((clubs: Club[]) => {
      this.clubs = clubs;
      this.cities = [...new Set(clubs.map(club => club.city))];
      console.log('Lista miast:', this.cities); // Logowanie listy miast
    });

    this.authService.user$.subscribe(user => {
      this.userId = user ? user.id : null;
    });
  }

  showClasses(city: string): void {
    console.log('Wybrane miasto:', city); // Logowanie wybranego miasta
    if (city) {
      this.fetchClassesByCity(city);
    }
  }

  fetchClassesByCity(city: string): void {
    const selectedClub = this.clubs.find(club => club.city === city);
    console.log('Wybrany klub:', selectedClub ? selectedClub.name : 'Brak'); // Logowanie wybranego klubu
    if (selectedClub) {
      this.reservationService.getClassesByClubId(selectedClub.id).subscribe((classes: Class[]) => {
        this.classes = classes;
        console.log('Pobrane zajęcia:', classes.map(c => c.name)); // Logowanie pobranych zajęć
      });
    } else {
      this.classes = [];
    }
  }

  reserveClass(classId: number): void {
    if (!this.userId) {
      alert('Nie zalogowano użytkownika');
      return;
    }
    const selectedClass = this.classes.find(c => c.id === classId);

    
    if (selectedClass && selectedClass.slots > 0) {
      this.reservationService.getUserReservations(this.userId).subscribe(reservations => {
        const alreadyReserved = reservations.some(reservation => reservation.classId === classId);
        if (alreadyReserved) {
          alert('Już masz rezerwację na te zajęcia');
          return;
        }})
      const updatedClass = { ...selectedClass, slots: selectedClass.slots - 1 };
      this.reservationService.reserveClass({ userId: this.userId, classId }).subscribe(() => {
        this.reservationService.updateClass(updatedClass).subscribe(() => {
          alert('Rezerwacja udana');
          const selectedClub = this.clubs.find(club => club.id === selectedClass.id);
          if (selectedClub) {
            this.fetchClassesByCity(selectedClub.city);
          }
        }, () => {
          alert('Aktualizacja slotów nieudana');
        });
      }, () => {
        alert('Rezerwacja nieudana');
      });
    } else {
      alert('Brak dostępnych miejsc');
    }
  }
}