using Microsoft.EntityFrameworkCore;
using Payment.Domain.Models;
using Payment.Domain.Models.Requests;
using Payment.Domain.Repositories.Interfaces;
using Payment.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.Repositories
{
    public class PaymentDetailRepository : IPaymentRepository
    {
        private readonly ApplicationDataContext _context;
        public PaymentDetailRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<PaymentDetailRequest> AddPaymentDetail(PaymentDetailRequest request)
        {
            var paymentDetail = new PaymentDetail
            {
                CardOwnerName = request.CardOwnerName,
                CardNumber = request.CardNumber,
                ExpirationDate = request.ExpirationDate,
                CVV = request.CVV,
                IsActive = request.IsActive,
            };
            _context.AddAsync(paymentDetail);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<bool?> DeletePaymentDetail(Guid id)
        {
            var paymentToDelete = await GetPaymentDetailsById(id);
            if (paymentToDelete == null)
            {
                return null;
            }
            _context.PaymentDetails.Remove(paymentToDelete);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool?> DesactivePaymentDetail(Guid id)
        {
            var paymentToDesactive = await GetPaymentDetailsById(id);
            paymentToDesactive.IsActive = false;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<PaymentDetail>> GetAllPaymentDetails()
        {
            return await _context.PaymentDetails.ToListAsync();
        }

        public async Task<PaymentDetail> GetPaymentDetailsById(Guid id)
        {
            return await _context.PaymentDetails.FindAsync(id);
        }

        public async Task<bool?> UpdatePaymentDetail(Guid id, PaymentDetailRequest request)
        {
            var paymentToUpdate = await GetPaymentDetailsById(id);
            if(paymentToUpdate == null)
            {
                return null;
            }
            paymentToUpdate.IsActive = request.IsActive;
            paymentToUpdate.CardOwnerName = request.CardOwnerName;
            paymentToUpdate.CardNumber = request.CardNumber;
            paymentToUpdate.ExpirationDate = request.ExpirationDate;
            paymentToUpdate.CVV = request.CVV;

            _context.PaymentDetails.Update(paymentToUpdate);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
