using ShipmentWebAPI.Models;

namespace ShipmentWebAPI.Services;

public interface IShipmentService
{
    void CreateShipment(Shipment shipment);
    Shipment GetShipment(int shipmentId);
    List<Shipment> GetAllShipments();
    void UpdateStatus(int shipmentId, string status);
    void CancelShipment(int shipmentId);
}