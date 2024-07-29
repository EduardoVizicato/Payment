import { Component, OnInit } from '@angular/core';
import { PaymentDetailService } from '../../shared/payment-detail.service';
import { FormsModule, NgForm } from '@angular/forms';
import { PaymentDetailRequest } from '../../shared/payment-detail-request.model';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-payment-details-form',
  standalone: true,
  imports: [FormsModule, RouterLink],
  templateUrl: './payment-details-form.component.html',
  styleUrl: './payment-details-form.component.scss',
})
export class PaymentDetailsFormComponent implements OnInit {
  model : PaymentDetailRequest = new PaymentDetailRequest();
  id: string = "";

  constructor(public service : PaymentDetailService, private router : Router, private route : ActivatedRoute) {
    
  }
  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const idParam = params.get('id');
      if (idParam) {
        this.id = idParam;
        this.loadPaymentDetail(this.id);
      }
    });
  }
  
  loadPaymentDetail(id: string): void {
    this.service.GetById(id).subscribe({
      next: (response) => {
        this.model = response;
      },
      error: (err) => {
        console.error('Erro ao carregar o pagamento', err);
      }
    });
  }
  
  onFormSubmit(form : NgForm) {
    if(form.valid){
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
  
}
