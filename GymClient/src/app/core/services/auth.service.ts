import { Injectable } from '@angular/core';
import { BehaviorSubject, catchError, map, Observable, of, ReplaySubject, tap, throwError } from "rxjs";
import { LoginForm, LoginResponseDto, RegisterForm, UserInfo } from '../../shared/models/user.model';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment.development';
import { Router } from '@angular/router';

@Injectable({
	providedIn: 'root'
})
export class AuthService {
	private userSource = new ReplaySubject<UserInfo | null>(1);
	public user$ = this.userSource.asObservable();
	public currentUser: UserInfo | null = null;

	constructor(private _http: HttpClient, private _router: Router) { }

	public register(form: RegisterForm): Observable<any> {
		return this._http.post<any>(`${environment.GymAPI}/register`, form);
	}

	public login(form: LoginForm): Observable<LoginResponseDto> {
		return this._http.post<LoginResponseDto>(`${environment.GymAPI}/login`, form).pipe(
			map((response) => {
				localStorage.setItem('accessToken', response.accessToken);
				document.cookie = `refreshToken=${response.refreshToken}`;
				this.getUserInfo().subscribe();
				return response;
			})
		);
	}

	public refreshToken(): Observable<LoginResponseDto> {
		const refreshToken = this.getRefreshTokenFromCookie();

		return this._http.post<LoginResponseDto>(`${environment.GymAPI}/refresh`, { refreshToken }).pipe(
			map((response) => {
				localStorage.setItem('accessToken', response.accessToken);
				document.cookie = `refreshToken=${response.refreshToken}`;
				return response;
			})
		);
	}

	public getUserInfo(): Observable<UserInfo> {
		return this._http.get<UserInfo>(`${environment.GymAPI}/userinfo`).pipe(
			map(response => {
				this.setUser(response);
				return response;
			})
		);
	}

	public logout() {
		localStorage.removeItem('accessToken');
		this.deleteRefreshTokenFromCookie();
		this.setUser(null);
		this._router.navigateByUrl("/");
	}

	public isUserLoggedIn$(): Observable<boolean> {
		return this.user$.pipe(
			map(user => user !== null)
		);
	}

	public setUser(user: UserInfo | null) {
		this.userSource.next(user);
		this.currentUser = user;
	}

	public getCurrentUserId(): string | null {
		return this.currentUser ? this.currentUser.id : null;
	  }

	private getRefreshTokenFromCookie(): string | null {
		const cookieString = document.cookie;
		const cookieArray = cookieString.split('; ');

		for (const cookie of cookieArray) {
			const [name, value] = cookie.split('=');

			if (name == 'refreshToken') {
				return value;
			}
		}
		return null;
	}

	private deleteRefreshTokenFromCookie(): void {
		document.cookie = 'refreshToken=; expires=Thu, 01 Jan 1970 00:00:00 GMT; path=/';
	}
}
