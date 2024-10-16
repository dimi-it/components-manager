using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DBManager.DTOs.Components.Resistors;

public class Resistor_SMD: IResistor
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; init; }
    public string Name { get; init; }
    public string? Description { get; init; }
    public string? ManufacturerProductCode { get; init; }
    public string? Manufacturer { get; init; }
    public string? VendorProductCode { get; init; }
    public string? Vendor { get; init; }
    public string Footprint { get; init; }
    public ComponentParameter<double> Resistance { get; init; }
    public ComponentParameter<string>? Tolerance { get; init; }     //TODO Maybe nullable?? who decide what value are essential and what not??
    public ComponentParameter<double>? Power { get; init; }                      
    public ComponentParameter<string>? TemperatureCoefficient { get; init; }                     
    public ComponentParameter<string>? Type { get; init; }                       
    public ComponentParameter<string>? OverloadVoltage { get; init; }                        
    public ComponentParameter<string>? OperatingTemperatureRange { get; init; }                      
}