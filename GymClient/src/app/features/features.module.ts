import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FeaturesRoutingModule } from './features-routing.module';
import { LoginComponent } from './user/login/login.component';
import { RegisterComponent } from './user/register/register.component';
import { MaterialModule } from '../shared/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TicketsComponent } from './tickets/tickets.component';
import { ContactComponent } from './contact/contact.component';
import { ClassReservationComponent } from './class-reservation/class-reservation.component';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { FitnessCarouselComponent } from './fitness-carousel/fitness-carousel.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';




@NgModule({
	declarations: [
		LoginComponent,
		RegisterComponent,
		TicketsComponent,
		ContactComponent,
  		ContactComponent,
  		ClassReservationComponent,
		FitnessCarouselComponent
	],
	imports: [
		CommonModule,
		FeaturesRoutingModule,
		ReactiveFormsModule,
		FormsModule,
		MaterialModule,
		CarouselModule.forRoot(),
		CarouselModule,
		NgbModule
	]
})
export class FeaturesModule { }
