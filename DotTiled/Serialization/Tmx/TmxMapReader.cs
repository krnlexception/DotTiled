using System;
using System.Collections.Generic;
using System.Xml;

namespace DotTiled;

public class TmxMapReader : IMapReader
{
  // External resolvers
  private readonly Func<string, Tileset> _externalTilesetResolver;
  private readonly Func<string, Template> _externalTemplateResolver;

  private readonly XmlReader _reader;
  private bool disposedValue;

  private readonly IReadOnlyCollection<CustomTypeDefinition> _customTypeDefinitions;

  public TmxMapReader(
    XmlReader reader,
    Func<string, Tileset> externalTilesetResolver,
    Func<string, Template> externalTemplateResolver,
    IReadOnlyCollection<CustomTypeDefinition> customTypeDefinitions)
  {
    _reader = reader ?? throw new ArgumentNullException(nameof(reader));
    _externalTilesetResolver = externalTilesetResolver ?? throw new ArgumentNullException(nameof(externalTilesetResolver));
    _externalTemplateResolver = externalTemplateResolver ?? throw new ArgumentNullException(nameof(externalTemplateResolver));
    _customTypeDefinitions = customTypeDefinitions ?? throw new ArgumentNullException(nameof(customTypeDefinitions));

    // Prepare reader
    _reader.MoveToContent();
  }

  public Map ReadMap()
  {
    return Tmx.ReadMap(_reader, _externalTilesetResolver, _externalTemplateResolver, _customTypeDefinitions);
  }

  protected virtual void Dispose(bool disposing)
  {
    if (!disposedValue)
    {
      if (disposing)
      {
        // TODO: dispose managed state (managed objects)
        _reader.Dispose();
      }

      // TODO: free unmanaged resources (unmanaged objects) and override finalizer
      // TODO: set large fields to null
      disposedValue = true;
    }
  }

  // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
  // ~TmxTiledMapReader()
  // {
  //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
  //     Dispose(disposing: false);
  // }

  public void Dispose()
  {
    // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
    Dispose(disposing: true);
    System.GC.SuppressFinalize(this);
  }
}