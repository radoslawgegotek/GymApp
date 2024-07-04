import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { MainModule } from './main/main.module';
import { MaterialModule } from './shared/material.module';
import { CoreModule } from './core/core.module';
import { provideHttpClient } from '@angular/common/http';
import { FeaturesModule } from './features/features.module';


@NgModule({
	declarations: [
		AppComponent,
	],
	imports: [
		BrowserModule,
		CoreModule,
		MainModule,
		FeaturesModule,
		AppRoutingModule,
		MaterialModule,
	],
	providers: [
		provideAnimationsAsync(),
		provideHttpClient()
	],
	bootstrap: [AppComponent]
})
export class AppModule { }
