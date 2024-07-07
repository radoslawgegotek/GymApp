import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FooterComponent } from './footer/footer.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { MaterialModule } from '../shared/material.module';
import { BrowserModule } from '@angular/platform-browser';
import { MainRoutingModule } from './main-routing.module';
import { ContactComponent } from '../features/contact/contact.component';
import { AdminComponent } from './admin/admin.component';
import { FormsModule } from '@angular/forms';
import { UserProfileComponent } from './user-profile/user-profile.component';

@NgModule({
	declarations: [
		FooterComponent,
		NavbarComponent,
		HomeComponent,
		NotFoundComponent,
 		 AdminComponent,
    UserProfileComponent,
	],
	imports: [
		CommonModule,
		BrowserModule,
		MaterialModule,
		MainRoutingModule,
		FormsModule, 
	],
	exports: [
		NavbarComponent,
		FooterComponent
	]
})
export class MainModule { }
