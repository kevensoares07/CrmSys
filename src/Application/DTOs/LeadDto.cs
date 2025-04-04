// Application/DTOs/LeadDto.cs
namespace Application.DTOs;

public class LeadDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Value { get; set; }
    public string Channel { get; set; } = string.Empty;
    public string Product { get; set; } = string.Empty;
    public string Urgency { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime? Followup { get; set; }
    public string PurchaseProduct { get; set; } = string.Empty;
    public string Payment { get; set; } = string.Empty;
    public string PurchaseReason { get; set; } = string.Empty;
    public string NoPurchaseReason { get; set; } = string.Empty;
    public string Messages { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}