import { Component, inject } from '@angular/core';
import { LoaderService } from '../../core/services/loader.service';
import { AuthService } from '../../core/services/auth.service';
import { Router } from '@angular/router';

@Component({
	selector: 'app-navbar',
	templateUrl: './navbar.component.html',
	styleUrl: './navbar.component.scss'
})
export class NavbarComponent {
	public loaderService = inject(LoaderService);
	public authService = inject(AuthService);



	constructor(
		private _authService: AuthService, private _router: Router,
	){}

	public logout() {
		this.authService.logout();
	}

	navigateToProfile() {
		const currentUserId = this.authService.getCurrentUserEmail();
	
		if (currentUserId === 'admin@admin.pl') {
		  this._router.navigate(['/admin']);
		} else {
		  this._router.navigate(['/user']);
		}
	  }
}
