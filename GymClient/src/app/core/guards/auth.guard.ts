import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { Observable, map, take, tap } from 'rxjs';

@Injectable({
	providedIn: 'root'
})
export class AuthGuard implements CanActivate {

	constructor(private authService: AuthService, private router: Router) { }

	canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
		return this.authService.user$.pipe(
			take(1),
			map(user => {
				const isLoggedIn = !!user;
				if (!isLoggedIn) {
					this.router.navigate(['login'], { queryParams: { redirect: state.url }, replaceUrl: true })
				}
				return isLoggedIn;
			})
		);
	}
}
