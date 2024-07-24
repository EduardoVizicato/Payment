using Payment.Domain.Models;
using Payment.Domain.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        Task<List<PaymentDetail>> GetAllPaymentDetails();
        Task<PaymentDetail> GetPaymentDetailsById(Guid id);
        Task<PaymentDetailRequest> AddPaymentDetail(PaymentDetailRequest request);
        Task<bool?> UpdatePaymentDetail(Guid id, PaymentDetailRequest request);
        Task<bool?> DeletePaymentDetail(Guid id);
        Task<bool?> DesactivePaymentDetail(Guid id);
    }
}
