import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';
import { RegisterForm } from '../../../shared/models/user.model';
import { Subject, takeUntil } from 'rxjs';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {
  form!: FormGroup;
  private _destroyed$ = new Subject<void>();

  constructor(
      private _authService: AuthService,
      private _fb: FormBuilder,
      private _router: Router
  ) {
      this.form = this.initRegisterForm();
  }

  ngOnDestroy(): void {
      this._destroyed$.next();
      this._destroyed$.complete();
  }

  registerUser() {
      if (this.form.valid) {
          const data = this.form.value as RegisterForm;

          this._authService.register(data)
              .pipe(takeUntil(this._destroyed$))
              .subscribe({
                  next: () => {
                      this._router.navigate(['login']);
                  }
              });
      }
  }

  private initRegisterForm(): FormGroup {
      return this._fb.group({
          email: ['', [Validators.required, Validators.email]],
          password: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(16)]]
      });
  }
}
