import { Routes } from '@angular/router';
import { PaymentDetailsComponent } from './payment-details/payment-details.component';
import { PaymentDetailsFormComponent } from './payment-details/payment-details-form/payment-details-form.component';

export const routes: Routes = [
    { path: 'payment-details/:id', component: PaymentDetailsFormComponent },
];
