using System;

namespace ExtensionMethods;

/// <summary>A collection of handy methods for Guids</summary>
public static class GuidExtension
{
    /// <summary>Converts a Content Asset ID to a Guid for i.e. Content.LoadAsync</summary>
    /// <param name="assetID">Asset ID from Content window</param>
    /// <returns>string</returns>
    public static Guid GuidFromAssetID(this string assetID)
    {
        return FlaxEngine.Json.JsonSerializer.ParseID(assetID);
    }
}
