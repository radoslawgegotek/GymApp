// src/app/components/class-reservation/class-reservation.component.ts
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ClassResponseDto } from '../../core/interface/class';
import { ClassService } from '../../core/services/class.service';
import { ClubService } from '../../core/services/club.service';

@Component({
  selector: 'app-class-reservation',
  templateUrl: './class-reservation.component.html',
  styleUrl: './class-reservation.component.scss'
})
export class ClassReservationComponent implements OnInit {
  cities: string[] = [];
  classes: ClassResponseDto[] = [];
  reservationForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private classService: ClassService,
    private clubService: ClubService
  ) {
    this.reservationForm = this.fb.group({
      city: ['']
    });
  }

  ngOnInit(): void {
    this.clubService.getClubs().subscribe(clubs => {
      this.cities = [...new Set(clubs.map(club => club.city))];
    });

    this.reservationForm.get('city')?.valueChanges.subscribe(city => {
      this.classService.getClassesByCity(city).subscribe(data => {
        this.classes = data;
      });
    });
  }

  reserveClass(classId: number): void {
    this.classService.reserveClass(classId).subscribe(response => {
      alert('Class reserved successfully');
    });
  }
}
