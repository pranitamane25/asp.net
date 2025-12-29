using PaymentApi.Models;

namespace PaymentApi.Services;

public interface IPaymentService
{
     Payment ProcessPayment(PaymentRequest request);
    Payment GetById(int id);
      bool RefundPayment(int id);

      List<Payment>GetAll();

   


}