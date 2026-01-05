using System.Text.Json;
using PaymentApi.Models;

namespace PaymentApi.Repositories;

public class PaymentRepository: IPaymentRepository
{
   private static readonly string _filePath = "Data/Payments.json";
  public Payment? GetById(int id)
  {
     List<Payment> payments= GetAll();
     return payments.FirstOrDefault(p => p.Id == id);

  }
  public List<Payment> GetAll()
  {
    List<Payment> payments = JsonSerializer.Deserialize<List<Payment>>(File.ReadAllText(_filePath));
    return payments;
  }
}

