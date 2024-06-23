import { Component } from '@angular/core';
import { LoginForm, LoginResponseDto } from '../../../shared/models/user.model';
import { Subject, takeUntil } from 'rxjs';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../../core/services/auth.service';
import { Router } from '@angular/router';

@Component({
	selector: 'app-login',
	templateUrl: './login.component.html',
	styleUrl: './login.component.scss'
})
export class LoginComponent {
	form!: FormGroup;
	private _destroyed$ = new Subject<void>();

	constructor(
		private _authService: AuthService,
		private _fb: FormBuilder,
		private _router: Router
	) {
		this.form = this.initLoginForm();
	}

	ngOnDestroy(): void {
		this._destroyed$.next();
		this._destroyed$.complete();
	}

	loginUser() {
		if (this.form.valid) {
			const data = this.form.value as LoginForm;

			this._authService.login(data)
				.pipe(takeUntil(this._destroyed$))
				.subscribe({
					next: (response: LoginResponseDto) => {
						this._router.navigate(['']);
					}
				});
		}
	}

	private initLoginForm(): FormGroup {
		return this._fb.group({
			email: this._fb.nonNullable.control('', [Validators.required, Validators.email]),
			password: this._fb.nonNullable.control('',
				[Validators.required, Validators.minLength(6), Validators.maxLength(16)])
		});
	}
}
