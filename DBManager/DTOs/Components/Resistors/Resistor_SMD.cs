﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DBManager.DTOs.Components.Resistors;

public class Resistor_SMD: Component, IResistor
{
    public required string Footprint { get; init; }
    public required ComponentParameter<double> Resistance { get; init; }
    public ComponentParameter<string>? Tolerance { get; init; }     //TODO Maybe nullable?? who decide what value are essential and what not??
    public ComponentParameter<double>? Power { get; init; }                      
    public ComponentParameter<string>? TemperatureCoefficient { get; init; }                     
    public ComponentParameter<string>? Type { get; init; }                       
    public ComponentParameter<string>? OverloadVoltage { get; init; }                        
    public ComponentParameter<string>? OperatingTemperatureRange { get; init; }
}