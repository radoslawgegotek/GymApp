import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { Session } from '../../shared/models/session.model';

declare const Stripe: any;

@Injectable({
	providedIn: 'root'
})
export class PaymentsService {

	constructor(private _http: HttpClient) { }

	public requestMemberSession(ticketTypeId: number, date: Date): void {
		this._http
			.post<Session>(`${environment.GymAPI}/api/UserPayments`, {
				ticketTypeId: ticketTypeId,
				expirationDate: date
			})
			.subscribe((session) => {
				this.redirectToCheckout(session);
			});
	}

	private redirectToCheckout(session: Session) {
		const stripe = Stripe(session.publicKey);

		stripe.redirectToCheckout({
			sessionId: session.sessionId,
		});
	}
}
