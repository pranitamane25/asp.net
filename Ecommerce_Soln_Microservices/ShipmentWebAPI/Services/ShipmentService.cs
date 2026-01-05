using Microsoft.AspNetCore.Mvc;
using ShipmentWebAPI.Helpers;
using ShipmentWebAPI.Models;
using ShipmentWebAPI.Repository;

namespace ShipmentWebAPI.Services;

public class ShipmentService : IShipmentService
{
    private readonly IShipmentRepository _repo;
    public ShipmentService(IShipmentRepository repo)
    {
        _repo = repo;
    }

    public void CreateShipment(Shipment shipment)
    {
        _repo.CreateShipment(shipment);
    }
    public Shipment GetShipment(int shipmentId)
    {
        return _repo.GetById(shipmentId);
    }
    public List<Shipment> GetAllShipments()
    {
        List<Shipment> list = _repo.GetAll();
        return list;
    }
    public void UpdateStatus(int shipmentId, string status)
    {
        _repo.UpdateShipment(shipmentId, status);
    }
    public void CancelShipment(int shipmentId)
    {
        _repo.DeleteShipmentById(shipmentId);
    }

}
