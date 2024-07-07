
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './user/login/login.component';
import { RegisterComponent } from './user/register/register.component';
import { AuthGuard } from '../core/guards/auth.guard';
import { TicketsComponent } from './tickets/tickets.component';
import { ContactComponent } from './contact/contact.component';
import { ClassReservationComponent } from './class-reservation/class-reservation.component';
import { FitnessCarouselComponent } from './fitness-carousel/fitness-carousel.component';


const routes: Routes = [
	{
		path: 'login',
		component: LoginComponent
	},
	{
		path: 'register',
		component: RegisterComponent,
	},
	{
		path: 'tickets',
		component: TicketsComponent
	},
	{
		path: 'contact',
		component: ContactComponent
	},
	{
		path: 'clubs',
		component: FitnessCarouselComponent
	},
	{ 	path: 'reserve-class',
		 component: ClassReservationComponent 
	},
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule]
})
export class FeaturesRoutingModule { }
