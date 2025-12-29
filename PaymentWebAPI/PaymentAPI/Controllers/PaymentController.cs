using Microsoft.AspNetCore.Mvc;
using PaymentApi.Services;
using PaymentApi.Models;

namespace ProductWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _service;

        public PaymentController(IPaymentService paymentService)
        {
            _service = paymentService;
        }

   // POST: api/payment/process----insert data 
        [HttpPost("process")]
        public IActionResult ProcessPayment([FromBody] PaymentRequest request)
        {
            var result = _service.ProcessPayment(request);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // GET: api/payment/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var payment = _service.GetById(id);

            if (payment == null)
                return NotFound(new { Message = "Payment not found" });

            return Ok(payment);
        }

        // PUT: api/payment/refund/{id}
        [HttpPut("refund/{id}")]
        public IActionResult RefundPayment(int id)
        {
            var success = _service.RefundPayment(id);

            if (!success)
                return BadRequest(new { Message = "Refund failed" });

            return Ok(new { Message = "Payment refunded" });
        }

        //api/payment
        [HttpGet]
        public IActionResult GetAll()
        {
            var payments = _service.GetAll();
            if (payments.Count == 0)
            {
                return Ok(new { Message = "No payments found", Data = payments });
            }
                return Ok (payments);
        }
        }

      
    }

