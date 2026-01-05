using System.Text.Json.Serialization;

namespace ShipmentWebAPI.Models;

public class Shipment
{
    [JsonPropertyName("shipmentId")]
    public int ShipmentId { get; set; }

    [JsonPropertyName("orderId")]
    public int OrderId { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    [JsonPropertyName("receiverName")]
    public string? ReceiverName { get; set; }

    [JsonPropertyName("pickUpAddress")]
    public string? PickUpAddress { get; set; }

    [JsonPropertyName("dropAddress")]
    public string? DropAddress { get; set; }

    [JsonPropertyName("createdDate")]
    public DateTime? CreatedDate { get; set; }

    [JsonPropertyName("deliveredDate")]
    public DateTime? DeliveredDate { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
