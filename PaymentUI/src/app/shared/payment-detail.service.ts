import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PaymentDetail } from './payment-detail.model';
import { PaymentDetailRequest } from './payment-detail-request.model';
@Injectable({
  providedIn: 'root'
})
export class PaymentDetailService {
  formData : PaymentDetail = new PaymentDetail();

  constructor(private http : HttpClient) { }

  Get(): Observable <PaymentDetail[]>{
    return this.http.get<PaymentDetail[]>(
      'https://localhost:7033/api/PaymentDetail'
    );
  }

  Post(paymentRequest: PaymentDetailRequest) : Observable <PaymentDetailRequest>{
    return this.http.post<PaymentDetailRequest>(
      'https://localhost:7033/api/PaymentDetail', paymentRequest
    );
  }
}
