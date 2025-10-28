
using FlaxEngine;

namespace ExtensionMethods;

/// <summary>
/// ExtensionMethodsPlugin GamePlugin.
/// </summary>
public class ExtensionMethodsPlugin : GamePlugin
{
    public ExtensionMethodsPlugin()
    {
        _description = new()
        {
            Name = "Extension Methods",
            Description = "A collection of convenience methods for Flax's C# API",
            Author = "Thomas Jungclaus",
            Category = "Extension Methods",
            IsAlpha = false,
            IsBeta = false,
            Version = new(1, 8, 7)
        };
    }
}