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

@NgModule({
	declarations: [
		FooterComponent,
		NavbarComponent,
		HomeComponent,
		NotFoundComponent,
	],
	imports: [
		CommonModule,
		BrowserModule,
		MaterialModule,
		MainRoutingModule
	],
	exports: [
		NavbarComponent,
		FooterComponent
	]
})
export class MainModule { }
