using PaymentApi.Models;

namespace PaymentApi.Repositories;

public interface IPaymentRepository
{
    //public List<Payment>GetAll();
    Payment? GetById(int id);
   // public Payment Add(Payment payment);
  
  //public bool Update(Payment payment);
}
