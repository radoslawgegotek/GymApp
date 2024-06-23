import { Injectable } from '@angular/core';
import {
	HttpRequest,
	HttpHandler,
	HttpEvent,
	HttpInterceptor,
	HttpErrorResponse
} from '@angular/common/http';
import { EMPTY, Observable, catchError, switchMap, throwError } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

	constructor(private authService: AuthService, private _router: Router) { }

	intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
		return next.handle(request).pipe(
			catchError(err => {
				if (err instanceof HttpErrorResponse) {
					switch (err.status) {
						case 401:
							return this.handle401Error(request, next);
						default:
							return throwError(() => err as unknown);
					}
				}
				return throwError(() => err as unknown);
			})
		);
	}

	private addToken(request: HttpRequest<any>): HttpRequest<any> {
		const accessToken = localStorage.getItem('accessToken');
		if (accessToken) {
			return request.clone({
				setHeaders: {
					Authorization: `Bearer ${accessToken}`
				}
			});
		}
		return request;
	}

	private handle401Error(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
		return this.authService.refreshToken().pipe(
			switchMap(() => {
				return next.handle(this.addToken(request))
			}),
			catchError((error) => {
				this.authService.setUser(null);
				return EMPTY;
			})
		)
	}
}
