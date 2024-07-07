import { Component, OnInit } from '@angular/core';
import { ClubResponseDto } from '../../core/interface/club';
import { ClubService } from '../../core/services/club.service';
import { Router } from '@angular/router';

interface Slide {
  id: number;
  name: string;
  city: string;
  description: string;
  address: string;
  phoneNumber: string;
}

@Component({
  selector: 'app-fitness-carousel',
  templateUrl: './fitness-carousel.component.html',
  styleUrl: './fitness-carousel.component.scss'
})
export class FitnessCarouselComponent implements OnInit {
  slides: Slide[] = [];

  constructor(private clubService: ClubService , private router: Router) {}

  ngOnInit(): void {
    this.clubService.getClubs().subscribe((clubs: ClubResponseDto[]) => {
      this.slides = clubs.map(club => ({
        id: club.id,
        name: club.name,
        city: club.city,
        description: club.description,
        address: club.address,
        phoneNumber: club.phoneNumber
      }));
    });
  }

  onSlideClick(slide: Slide): void {
    this.router.navigate(['tickets']);
  }
}
