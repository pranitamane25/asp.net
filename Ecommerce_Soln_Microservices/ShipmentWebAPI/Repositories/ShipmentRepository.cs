using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using ShipmentWebAPI.Helpers;
using ShipmentWebAPI.Models;

namespace ShipmentWebAPI.Repository;

public class ShipmentRepository : IShipmentRepository
{
    private readonly string _filePath = "Data/shipment.json";
    private static readonly object _lock = new();
    public List<Shipment> GetAll()
    {
        return JsonHelper.GetShipments();
    }
    public void CreateShipment(Shipment shipment)
    {
        lock (_lock)
        {
            List<Shipment> shipments = GetAll();
            shipments.Add(shipment);
            JsonHelper.Save(shipments);
        }
    }
    public void UpdateShipment(int id, string status)
    {
        lock (_lock)
        {
            List<Shipment> shipments = JsonHelper.GetShipments();
            Shipment shipment = shipments.FirstOrDefault(s => s.ShipmentId == id);
            if (shipment == null) return;
            shipment.Status = status;
            JsonHelper.Save(shipments);
        }
    }
    public void DeleteShipmentById(int id)
    {
        lock (_lock)
        {
            List<Shipment> shipments = JsonHelper.GetShipments();
            Shipment shipment = shipments.FirstOrDefault(s => s.ShipmentId == id);
            shipments.Remove(shipment);
            JsonHelper.Save(shipments);
        }
    }
    public Shipment GetById(int id)
    {
        List<Shipment> shipments = GetAll();
        Shipment? shipment = shipments.FirstOrDefault(s => s.ShipmentId == id);
        return shipment;
    }
}