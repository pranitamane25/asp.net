using PaymentApi.Models;
using PaymentApi.Repositories;

namespace PaymentApi.Services;

public class PaymentService : IPaymentService
{ 
    private readonly IPaymentRepository _repo;
    public PaymentService(IPaymentRepository repo)
    {
        _repo = repo;
    }

       public Payment ProcessPayment(PaymentRequest request)
        {
            var payments = _repo.GetAll();

            var payment = new Payment
            {
                Id = payments.Count == 0 ? 1 : payments.Max(p => p.Id) + 1,
                Amount = request.Amount
            };

            _repo.Add(payment);
            return payment;
        }
    public Payment GetById(int id)
    {
        return _repo.GetById(id);
 
    }

    public bool RefundPayment(int id)
    {
            var payment = _repo.GetById(id);
            if (payment == null)
                return false;

            payment.Status = "Refunded";
            _repo.Update(payment);
            return true;
        }

        public List<Payment> GetAll()
    {
        return _repo.GetAll();
    }
    }
