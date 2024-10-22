namespace DBManager.DTOs.Components;

public interface IComponent: IStrippedComponent
{
    string? Description { get; }
    
    string? DatasheetUrl { get; }
    List<string>? ImagesUrl { get; }
}