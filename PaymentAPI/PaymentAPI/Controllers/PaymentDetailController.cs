using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Payment.Domain.Models.Requests;
using Payment.Domain.Repositories.Interfaces;

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController(IPaymentRepository repository) : ControllerBase
    {
        private readonly IPaymentRepository _repository = repository;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _repository.GetAllPaymentDetails();

            if (data.Count == 0)
            {
                return NoContent();
            }

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var data = await _repository.GetPaymentDetailsById(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }
        [HttpPost]

        public async Task<IActionResult> Add([FromBody] PaymentDetailRequest request)
        {
            var contactId = await _repository.AddPaymentDetail(request);

            return CreatedAtAction(nameof(Get), new { Id = contactId }, request);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(Guid id, [FromBody] PaymentDetailRequest request)
        {
            var updated = await _repository.UpdatePaymentDetail(id, request);

            if (updated == null)
            {
                return NotFound();
            }

            if (!updated.Value)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("Desactive/{id}")]

        public async Task<IActionResult> Desactive(Guid id)
        {
            var desactived = await _repository.DesactivePaymentDetail(id);
            if (desactived == null)
            {
                return NotFound();
            }
            if (!desactived.Value)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _repository.DeletePaymentDetail(id);
            if (deleted == null)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
