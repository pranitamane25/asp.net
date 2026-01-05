using System.Text.Json;
using ShipmentWebAPI.Models;
namespace ShipmentWebAPI.Helpers;

public static class JsonHelper
{
    private static readonly string _filePath = "Data/Shipment.json";

    public static List<Shipment> GetShipments()
    {
        if (!File.Exists(_filePath))
            return new List<Shipment>();

        var json = File.ReadAllText(_filePath);

        return JsonSerializer.Deserialize<List<Shipment>>(json)
               ?? new List<Shipment>();
    }

    public static void Save(List<Shipment> shipments)
    {
        var json = JsonSerializer.Serialize(shipments, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(_filePath, json);
    }
}
