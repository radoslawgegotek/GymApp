import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CheckoutFailComponent } from './checkoutfail/checkoutfail.component';
import { CheckoutSucceededComponent } from './checkoutsucceeded/checkoutsucceeded.component';

const routes: Routes = [
	{
		path: 'checkout-fail',
		component: CheckoutFailComponent
	},
	{
		path: 'checkout-succeeded',
		component: CheckoutSucceededComponent
	}
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule]
})
export class MainRoutingModule { }
