import { Component } from '@angular/core';
import { PaymentDetailService } from '../../shared/payment-detail.service';
import { FormsModule } from '@angular/forms';
import { PaymentDetailRequest } from '../../shared/payment-detail-request.model';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-payment-details-form',
  standalone: true,
  imports: [FormsModule, RouterLink],
  templateUrl: './payment-details-form.component.html',
  styleUrl: './payment-details-form.component.scss'
})
export class PaymentDetailsFormComponent {
  model : PaymentDetailRequest = new PaymentDetailRequest();
  constructor(public service : PaymentDetailService, private router : Router) {

  }


  onFormSubmit() {
    this.service.Post(this.model).subscribe({
      next: (response) => {
        console.log(response);
      },
      error: (err) => {
        console.error(err);
      }
    });
  }
}
