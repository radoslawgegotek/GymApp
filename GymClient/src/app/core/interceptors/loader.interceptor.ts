import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { finalize, catchError } from 'rxjs/operators';
import { LoaderService } from '../services/loader.service';

@Injectable()
export class LoaderInterceptor implements HttpInterceptor {
	constructor(private loaderService: LoaderService) { }

	intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
		this.loaderService.isLoading.next(true);
		return next.handle(req).pipe(
			finalize(() => {
				this.loaderService.isLoading.next(false);
			}),
			catchError((error: HttpErrorResponse) => {
				this.loaderService.isLoading.next(false);
				throw error;
			})
		);
	}
}
