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

       // ADD
    public void Add(Payment payment)
    {
        List<Payment> payments = GetAll();

        payment.Id = payments.Count == 0 ? 1 : payments.Max(p => p.Id) + 1;
        payments.Add(payment);

        SaveAll(payments);
    }

        // UPDATE (for Refund)
   public void Update(Payment payment){
        List<Payment> payments = GetAll();

        var index = payments.FindIndex(p => p.Id == payment.Id);
        if (index == -1)
            
        payments[index] = payment;
        SaveAll(payments);
    }

      // SAVE ALL (helper)
    private void SaveAll(List<Payment> payments)
    {
        var json = JsonSerializer.Serialize(payments, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(_filePath, json);
    }
  }


