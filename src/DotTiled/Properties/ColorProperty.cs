namespace DotTiled;

/// <summary>
/// Represents a color property.
/// </summary>
public class ColorProperty : IProperty<Color>
{
  /// <inheritdoc/>
  public required string Name { get; set; }

  /// <inheritdoc/>
  public PropertyType Type => PropertyType.Color;

  /// <summary>
  /// The color value of the property.
  /// </summary>
  public required Color Value { get; set; }

  /// <inheritdoc/>
  public IProperty Clone() => new ColorProperty
  {
    Name = Name,
    Value = Value
  };
}