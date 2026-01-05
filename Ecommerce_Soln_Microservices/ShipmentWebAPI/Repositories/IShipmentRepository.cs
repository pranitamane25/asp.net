using ShipmentWebAPI.Models;

namespace ShipmentWebAPI.Repository;

public interface IShipmentRepository
{
    List<Shipment> GetAll();
    void CreateShipment(Shipment shipment);
    void DeleteShipmentById(int id);
    Shipment GetById(int id);
    void UpdateShipment(int id, string status);
}