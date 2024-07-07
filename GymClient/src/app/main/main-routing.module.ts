import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin/admin.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
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
  {
		path: 'admin',
		component: AdminComponent
	},
  {
		path: 'user',
		component: UserProfileComponent
  },
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule]
})
export class MainRoutingModule { }
