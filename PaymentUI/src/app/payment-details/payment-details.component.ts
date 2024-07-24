import { Component, OnInit } from '@angular/core';
import { PaymentDetailsFormComponent } from "./payment-details-form/payment-details-form.component";
import { PaymentDetailService } from '../shared/payment-detail.service';
import { CommonModule, NgFor } from '@angular/common';
import { PaymentDetail } from '../shared/payment-detail.model';

@Component({
  selector: 'app-payment-details',
  standalone: true,
  imports: [PaymentDetailsFormComponent, NgFor, CommonModule],
  templateUrl: './payment-details.component.html',
  styleUrl: './payment-details.component.scss'
})
export class PaymentDetailsComponent implements OnInit {

  paymentDetails? : PaymentDetail[];

  constructor(public service : PaymentDetailService) {

  }
  ngOnInit(): void {
    this.service.Get()
    .subscribe({
      next: (response) =>{
        this.paymentDetails = response;
      }
    })
  }

}
