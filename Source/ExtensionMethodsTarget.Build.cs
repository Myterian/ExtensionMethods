using Flax.Build;

public class ExtensionMethodsTarget : GameProjectTarget
{
    /// <inheritdoc />
    public override void Init()
    {
        base.Init();

        // Reference the modules for game
        Modules.Add(nameof(ExtensionMethods));
    }
}
