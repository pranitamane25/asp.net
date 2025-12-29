using PaymentApi.Models;

namespace PaymentApi.Repositories;

public interface IPaymentRepository
{
    public List<Payment>GetAll();
    Payment? GetById(int id);
   public void Add(Payment payment);
  
  public void Update(Payment payment);

}
