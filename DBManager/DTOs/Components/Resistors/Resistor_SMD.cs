using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DBManager.DTOs.Components.Resistors;

public class Resistor_SMD: IResistor
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    //Try to move it to the interface by using the init also on it!!
    public string Id { get; init; }
    public string Name { get; init; }
    public string? Description { get; init; }
    public string? ManufacturerProductCode { get; init; }
    public string? Manufacturer { get; init; }
    public string? VendorProductCode { get; init; }
    public string? Vendor { get; init; }
    public string Footprint { get; init; }
    public ComponentParameter<double> Resistance { get; init; }
    public ComponentParameter<string> Tolerance { get; init; }
    public ComponentParameter<double> Power { get; init; }                      //Maybe nullable?? who decide what value are essential and what not??
    public ComponentParameter<string> TemperatureCoefficient { get; init; }     //Maybe nullable?? who decide what value are essential and what not??                
    public ComponentParameter<string> Type { get; init; }                       //Maybe nullable?? who decide what value are essential and what not??
    public ComponentParameter<string> OverloadVoltage { get; init; }            //Maybe nullable?? who decide what value are essential and what not??            
    public ComponentParameter<string> OperatingTemperatureRange { get; init; }  //Maybe nullable?? who decide what value are essential and what not??                    
}