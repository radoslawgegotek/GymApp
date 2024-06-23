import { Component, inject } from '@angular/core';
import { LoaderService } from '../../core/services/loader.service';
import { AuthService } from '../../core/services/auth.service';

@Component({
	selector: 'app-navbar',
	templateUrl: './navbar.component.html',
	styleUrl: './navbar.component.scss'
})
export class NavbarComponent {
	public loaderService = inject(LoaderService);
	public authService = inject(AuthService);


	public logout() {
		this.authService.logout();
	}
}
